using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives.PopupPositioning;
using Avalonia.Input;
using Avalonia.VisualTree;

namespace Sample.Avalonia;

public class FlyoutPopup : Flyout {
    private readonly object flayoutLock = new object();

    public FlyoutPopup() {
        ShowMode = FlyoutShowMode.Standard;
        Popup.Focusable = true;
        Popup.IsEnabled = true;
        Content = new PopupFlyoutView();

        if (Content is Control view) {
            view.Focusable = true;
        }
    }

    public void ShowPopup(Control target) {
            lock (flayoutLock) {
                if (target is not null) {
                    SetAttachedFlyout(target, null);
                    ShowAtCore(target, true);
                }
            }
    }
}