/*** Auto-generated ***/

namespace Sample.Avalonia {

    using BaseComponent = Sample.Avalonia.ExtendedReactView;
    using BaseModule = ReactViewControl.ViewModuleContainer;

    public delegate void MainViewMouseOverEventHandler(double clientX, double clientY);
    public delegate void MainViewMouseLeaveEventHandler();

    

    public partial interface IMainViewModule {
        event MainViewMouseOverEventHandler MouseOver;
        event MainViewMouseLeaveEventHandler MouseLeave;
    }
    
    public partial interface IMainView : IMainViewModule {}

    public partial class MainViewModule : BaseModule, IMainViewModule {
        
        internal interface IProperties {
            void MouseOver(double clientX, double clientY);
            void MouseLeave();
        }
        
        private class Properties : IProperties {
            protected MainViewModule Owner { get; }
            public Properties(MainViewModule owner) => Owner = owner;
            public void MouseOver(double clientX, double clientY) => Owner.MouseOver?.Invoke(clientX, clientY);
            
            public void MouseLeave() => Owner.MouseLeave?.Invoke();
            
        }
        
        public event MainViewMouseOverEventHandler MouseOver;
        public event MainViewMouseLeaveEventHandler MouseLeave;
        
        protected override string MainJsSource => "/Sample.Avalonia/Generated/MainView.js";
        protected override string NativeObjectName => "MainView";
        protected override string ModuleName => "MainView";
        protected override object CreateNativeObject() => new Properties(this);
        protected override string[] Events => new string[] { "mouseOver","mouseLeave" };
        
        #if DEBUG
        protected override string Source => "/Users/sandeep.pal/Documents/ServiceStudio/ReactView-SampleAvalonia/Sample.Avalonia/Generated/MainView.js";
        #endif
    }
    
    public partial class MainView : BaseComponent, IMainViewModule {
    
        public MainView() : base(new MainViewModule()) {
            InitializeMainView();
        }
    
        partial void InitializeMainView();
    
        protected new MainViewModule MainModule => (MainViewModule) base.MainModule;
    
        public event MainViewMouseOverEventHandler MouseOver {
            add => MainModule.MouseOver += value;
            remove => MainModule.MouseOver -= value;
        }
        public event MainViewMouseLeaveEventHandler MouseLeave {
            add => MainModule.MouseLeave += value;
            remove => MainModule.MouseLeave -= value;
        }
    }

}