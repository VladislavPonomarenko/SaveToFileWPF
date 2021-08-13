using SaveToFileBLL.Interfaces;
using SaveToFileWPF.ViewModels;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;

namespace SaveToFileWPF.Screens.MainWindow
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Interfaces

        private readonly ISaver _saver;
        private readonly IExport _export;

        #endregion

        #region ObservableCollections

        public ObservableCollection<UserViewModel> UserVMs { get; set; }
        public ObservableCollection<UserViewModel> SelectedVMs { get; }
        public ObservableCollection<FileFormatViewModel> FileFormatVMs { get; }

        #endregion

        #region Constructors

        public MainWindowViewModel(ISaver saver, IExport export)
        {
            _saver = saver;
            _export = export;

            UserVMs = new ObservableCollection<UserViewModel>();
            SelectedVMs = new ObservableCollection<UserViewModel>();
            FileFormatVMs = new ObservableCollection<FileFormatViewModel>();

            ReloadCommand.Execute(null);
        }

        #endregion

        #region Virtual functions

        protected override void Load()
        {
            FillUpUserVMs();
            FillUpFileFormatVMs();
        }

        #endregion

        #region Internal functions

        private void FillUpUserVMs()
        {
            UserVMs.Add(new UserViewModel("Liam", 12, "Las Boyem"));
            UserVMs.Add(new UserViewModel("Olivia", 24, "Merlat"));
            UserVMs.Add(new UserViewModel("Oliver", 8, "Grand"));
            UserVMs.Add(new UserViewModel("Ava", 16, "Santa Linsrai"));

            UserVMs = new ObservableCollection<UserViewModel>(UserVMs.OrderBy(u => u.Name));
        }

        private void FillUpFileFormatVMs()
        {
            FileFormatVMs.Add(new FileFormatViewModel("Экспорт в CSV", "csv", ExportToFile));
            FileFormatVMs.Add(new FileFormatViewModel("Экспорт в TXT", "txt", ExportToFile));
        }

        private string ObjectsToString(string separator)
        {
            var stringBuilder = new StringBuilder();

            foreach (var userVM in SelectedVMs.OrderBy(u => u.Name))
            {
                stringBuilder.Append(userVM.Name + separator);
                stringBuilder.Append(userVM.Age + separator);
                stringBuilder.Append(userVM.City);
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        private void ExportToFile(FileFormatViewModel fileFormatVM)
        {
            var stringResult = ObjectsToString(",");
            _export.ExportToFile(_saver, fileFormatVM.FileFormat, stringResult);
        }

        #endregion
    }
}