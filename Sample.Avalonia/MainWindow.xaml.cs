using System.Collections;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace Sample.Avalonia {

    internal class MainWindow : Window {

        private int counter = 1;

        private TabControl tabs;
        
        private TooltipService tooltipService;

        public MainWindow() {
            AvaloniaXamlLoader.Load(this);
            tooltipService = new TooltipService();

            tabs = this.FindControl<TabControl>("tabs");

            CutCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Cut();
            });

            CopyCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Copy();
            });

            PasteCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Paste();
            });

            UndoCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Undo();
            });

            RedoCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Redo();
            });

            SelectAllCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.SelectAll();
            });

            DeleteCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Delete();
            });

            CreateTab();

#if DEBUG
            this.AttachDevTools(new KeyGesture(Key.F5));
#endif
        }

        public void CreateTab() {
            var item = new TabItem() { Header = "View " + counter, Content = new TabView(counter), };
            item.PointerEntered += ((sender, args) => {
                tooltipService.ShowTooltip(item, item.Header?.ToString() + " testing it for position issue", args.GetPosition(this).X + 10, args.GetPosition(this).Y + 10);
            });
            
            item.PointerExited += ((sender, args) => {
                tooltipService.HideTooltip();
            });
            ((IList)tabs.Items).Add(item);
            
            counter++;
        }

        private TabView SelectedView => (TabView) tabs.SelectedContent;

        private void OnNewTabClick(object sender, RoutedEventArgs e) => CreateTab();

        private void OnToggleThemeStyleSheetMenuItemClick(object sender, RoutedEventArgs e) => Settings.IsLightTheme = !Settings.IsLightTheme;

        private void OnShowDevToolsMenuItemClick(object sender, RoutedEventArgs e) => SelectedView.ShowDevTools();

        private void OnToggleIsEnabledMenuItemClick(object sender, RoutedEventArgs e) => SelectedView.ToggleIsEnabled();

        public ReactiveCommand<Unit, Unit> CutCommand { get; }

        public ReactiveCommand<Unit, Unit> CopyCommand { get; }

        public ReactiveCommand<Unit, Unit> PasteCommand { get; }

        public ReactiveCommand<Unit, Unit> UndoCommand { get; }

        public ReactiveCommand<Unit, Unit> RedoCommand { get; }

        public ReactiveCommand<Unit, Unit> SelectAllCommand { get; }

        public ReactiveCommand<Unit, Unit> DeleteCommand { get; }
    }
}