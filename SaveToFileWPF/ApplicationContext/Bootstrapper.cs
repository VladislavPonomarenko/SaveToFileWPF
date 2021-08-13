using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using SaveToFileBLL.Interfaces;
using SaveToFileBLL.Services;
using SaveToFileWPF.Screens.MainWindow;
using SaveToFileWPF.Services;

namespace SaveToFileWPF.ApplicationContext
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }

        protected override void Configure()
        {
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.PerRequest<MainWindowViewModel>();
            _container.PerRequest<ISaver, Saver>();
            _container.PerRequest<IExport, Export>();
            base.Configure();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}