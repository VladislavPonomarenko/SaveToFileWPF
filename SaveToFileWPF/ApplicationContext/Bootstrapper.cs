using System.Windows;
using Caliburn.Micro;
using SaveToFileWPF.Screens.MainWindow;

namespace SaveToFileWPF.ApplicationContext
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
    }
}