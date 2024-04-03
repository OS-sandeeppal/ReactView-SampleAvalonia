using System;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using ReactViewControl;

namespace Sample.Avalonia;

internal class TabView : ContentControl {
    private readonly object flayoutLock = new();

    protected override Type StyleKeyOverride => typeof(ContentControl);

    private readonly MainView mainView;

    public TabView(int id) {
        mainView = new MainView();
        mainView.Focusable = true;
        Content = mainView;

        mainView.ShowFlyoutButtonClicked += OnFlyoutButtonClicked;
    }

    public void ShowDevTools() {
        mainView.ShowDeveloperTools();
    }

    public void ToggleIsEnabled() {
        mainView.IsEnabled = !mainView.IsEnabled;
    }

    public EditCommands EditCommands => mainView.EditCommands;

    private void OnFlyoutButtonClicked(bool useFlyoutBase) {
        Dispatcher.UIThread.Post(action: () => {
            var popupFlyoutView = new PopupFlyoutView();
            popupFlyoutView.Height = 600;
            popupFlyoutView.Width = 600;

            if (useFlyoutBase) {
                var flyout = new Flyout() { Content = popupFlyoutView };
                mainView.Focusable = true;
                mainView.IsEnabled = true;

                FlyoutBase.SetAttachedFlyout(mainView, value: flyout);
                FlyoutBase.ShowAttachedFlyout(mainView);
            } else {
                var flyout = new FlyoutPopup { Content = popupFlyoutView };
                flyout.ShowPopup(mainView);
            }
        });
    }
}