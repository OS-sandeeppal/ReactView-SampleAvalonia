using System;
using Avalonia.Controls;

namespace Sample.Avalonia {

    internal class TabView : ContentControl {

        protected override Type StyleKeyOverride => typeof(ContentControl);

        private MainView mainView;
        private TooltipService tooltipService;

        public TabView(int id) {
            tooltipService = new TooltipService();
            mainView = new MainView();
            mainView.MouseOver += (clientX, clientY) => {
                tooltipService.ShowTooltip(this, "This is test tooltip", clientX, clientY);
            };

            mainView.MouseLeave += () => {
                tooltipService.HideTooltip();
            };
            
            mainView.Focusable = true;
            Content = mainView;
        }

        public void ShowDevTools() => mainView.ShowDeveloperTools();

        public void ToggleIsEnabled() => mainView.IsEnabled = !mainView.IsEnabled;

        public ReactViewControl.EditCommands EditCommands => mainView.EditCommands;
    }
}
