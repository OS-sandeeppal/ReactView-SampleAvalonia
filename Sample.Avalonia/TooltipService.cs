using System;
using System.Collections.Concurrent;
using System.Reactive.Disposables;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Primitives.PopupPositioning;
using Avalonia.Media;
using Avalonia.Threading;
using Avalonia.VisualTree;

namespace Sample.Avalonia;

internal class TooltipService {
    private const int BorderThickness = 1;
    private const int CornerRadiusOSX = 9;
    private const int CornerRadiusWindows = 8;
    private const int DropShadowBlurRadius = 20;
    private const int DropShadowDepth = 20;
    private const int DropShadowDirection = 5;
    private const double DropShadowOpacity = 0.2;
    private const int MarginThickness = 10;
    private const int Padding = 2;
    private const int VerticalDistanceFromPointer = 10;

    private readonly object tooltipLock = new();
    private readonly ConcurrentStack<IDisposable> tooltipDisposables = new();
    
    private IDisposable showTooltipDelayedTask;

    public void ShowTooltip(Control target, string data, double x, double y) {
        void Show() => InnerShowTooltip(target, data, x, y);

        lock (tooltipLock) {
            showTooltipDelayedTask?.Dispose();
        }

        Dispatcher.UIThread.InvokeAsync(Show);
    }

    public void HideTooltip() {
        lock (tooltipLock) {
            showTooltipDelayedTask?.Dispose();
            foreach (var disposable in tooltipDisposables) {
                disposable.Dispose();
            }
            
            tooltipDisposables.Clear();
        }
    }

    private static void InnerHideTooltip(Control control) {
        if (control is not Popup tooltip) {
            return;
        }

        var contentView = (tooltip.Child as ContentControl)?.Content as ExtendedReactView;
        if (tooltip.IsOpen) {
            tooltip.Close();
        }
        contentView?.Dispose();
    }

    private void InnerShowTooltip(Control target, string data, double x, double y) {
        lock (tooltipLock) {
            HideTooltip();

            // only show tooltips when the window is active
            if (target.GetVisualRoot() is not Window { IsActive: true, IsVisible: true } window) {
                return;
            }

            var tooltip = new Popup {
                Child = new ContentControl { Content = data },
                Focusable = false,
                HorizontalOffset = x,
                Placement = PlacementMode.AnchorAndGravity,
                PlacementConstraintAdjustment = PopupPositionerConstraintAdjustment.FlipX | PopupPositionerConstraintAdjustment.FlipY,
                PlacementGravity = PopupGravity.BottomRight,
                PlacementAnchor = PopupAnchor.TopLeft,
                PlacementRect = MeasurePlacementRect(window, target, x, y),
                PlacementTarget = target,
                VerticalOffset = y + VerticalDistanceFromPointer,
                WindowManagerAddShadowHint = false,
                TakesFocusFromNativeControl = false
            };

            var content = (ContentControl)tooltip.Child;
            content.Margin = new Thickness(MarginThickness);
            content.Padding = new Thickness(Padding);

            content.CornerRadius = new CornerRadius(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? CornerRadiusWindows : CornerRadiusOSX);

            if (Application.Current.TryGetResource("ThemeBackgroundBrush", Application.Current.ActualThemeVariant, out var backgroundBrushObj) && backgroundBrushObj is IBrush backgroundBrush) {
                content.Background = backgroundBrush;
            }

            if (Application.Current.TryGetResource("ThemeBorderMidBrush", Application.Current.ActualThemeVariant, out var borderBrushObj) && borderBrushObj is IBrush borderBrush) {
                content.BorderBrush = borderBrush;
                content.BorderThickness = new Thickness(BorderThickness);
            }

            content.Effect = new DropShadowDirectionEffect {
                ShadowDepth = DropShadowDepth,
                BlurRadius = DropShadowBlurRadius,
                Opacity = DropShadowOpacity,
                Color = Colors.Black,
                Direction = DropShadowDirection
            };

            ((ISetLogicalParent)tooltip).SetParent(window);

            void OnTargetDetachedFromVisualTree(object sender, VisualTreeAttachmentEventArgs e) => HideTooltip();

            target.DetachedFromVisualTree += OnTargetDetachedFromVisualTree;

            void OnDisposeTooltip() {
                target.DetachedFromVisualTree -= OnTargetDetachedFromVisualTree;

                Dispatcher.UIThread.InvokeAsync(() => InnerHideTooltip(tooltip));
            }
            var disposable = Disposable.Create(OnDisposeTooltip);

            tooltip.Open();
            tooltipDisposables.Push(disposable);
        }
    }

    private static Rect MeasurePlacementRect(Window window, Visual target, double x, double y) {
        var renderScaling = window.RenderScaling;

        // Calculate scaled window bounds
        var scaledWindowBounds = new PixelRect(
            x: (int)(window.Position.X * renderScaling),
            y: (int)(window.Position.Y * renderScaling),
            width: (int)(window.Bounds.Width * renderScaling),
            height: (int)(window.Bounds.Height * renderScaling)
        );

        var controlPosition = target.PointToScreen(new Point(target.Bounds.Position.X, target.Bounds.Position.Y));

        // Calculate the scaled position of the cursor within the browser
        var scaledCursorX = (int)(x * renderScaling);
        var scaledCursorY = (int)(y * renderScaling);

        var activeScreen = window.Screens.ScreenFromBounds(new PixelRect(controlPosition.X + scaledCursorX, controlPosition.Y + scaledCursorY, 1, 1));
        return activeScreen == null ? default : scaledWindowBounds.Intersect(activeScreen.Bounds).ToRectWithDpi(renderScaling);
    }
}