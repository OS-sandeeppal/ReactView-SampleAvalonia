using System;
using Avalonia.Controls;

namespace Sample.Avalonia {

    internal class TabView : ContentControl {

        protected override Type StyleKeyOverride => typeof(ContentControl);

        private MainView mainView;

        public TabView(int id) {
            mainView = new MainView();
            mainView.Focusable = true;
            Content = mainView;
        }

        public void ShowDevTools() => mainView.ShowDeveloperTools();

        public void ToggleIsEnabled() => mainView.IsEnabled = !mainView.IsEnabled;

        public ReactViewControl.EditCommands EditCommands => mainView.EditCommands;
    }
}
