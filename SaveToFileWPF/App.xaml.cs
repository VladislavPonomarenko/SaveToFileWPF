using SaveToFileWPF.ApplicationContext;
using System.Windows;

namespace SaveToFileWPF
{
    public partial class App : Application
    {
        private Bootstrapper _bootstrapper;

        public App()
        {
            _bootstrapper = new Bootstrapper();
        }
    }
}