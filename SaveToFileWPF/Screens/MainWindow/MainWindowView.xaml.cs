using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Grid;
using System.Windows;

namespace SaveToFileWPF.Screens.MainWindow
{
    public partial class MainWindowView : Window
    {
       
        public MainWindowView()
        {
            InitializeComponent();
        }

        void TableView_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            if (DataContext is not MainWindowViewModel vm)
                return;

            if (e.MenuType == GridMenuType.RowCell)
            {
                foreach(var fileFormatVM in vm.FileFormatVMs)
                    e.Customizations.Add(new BarButtonItem
                    { 
                        Content = fileFormatVM.Title,
                        Command = fileFormatVM.ExportToFileCommand
                    });
            }
        }
    }
}
