﻿using NUnit.Framework;

namespace Tests {

    public class TestReactCustomInitializationView : TestReactView {

        private readonly object component;

        public TestReactCustomInitializationView() : base(explicitInitialization: true) {
            component = base.CreateNativeObject();
            Initialize();
        }

        protected override object CreateNativeObject() {
            Assert.IsNotNull(component);
            return base.CreateNativeObject();
        }
    }

    public class ReactViewInitializationTests : ReactViewTestBase<TestReactCustomInitializationView> {

        [Test(Description = "Test loading a react component with a fullpath source")]
        public void ComponentWithSourceAndRootPropertiesLateBound() {
            // reaching this point means success
        }
    }
}