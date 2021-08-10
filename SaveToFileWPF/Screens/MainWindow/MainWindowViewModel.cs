using SaveToFileBLL.Interfaces;
using SaveToFileBLL.Services;
using SaveToFileWPF.Commands;
using SaveToFileWPF.Helpers;
using SaveToFileWPF.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace SaveToFileWPF.Screens.MainWindow
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Interfaces

        private ISaver _saver;

        #endregion

        #region ObservableCollections

        public ObservableCollection<UserViewModel> UserVMs { get; }
        public ObservableCollection<UserViewModel> SelectedVMs { get; }

        #endregion

        #region RelayCommands

        public RelayCommand ExportToCSVCommand { get; set; }
        public RelayCommand ExportToTXTCommand { get; set; }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            UserVMs = new ObservableCollection<UserViewModel>();
            SelectedVMs = new ObservableCollection<UserViewModel>();

            ExportToCSVCommand = new RelayCommand(ExportToCSVFile);
            ExportToTXTCommand = new RelayCommand(ExportToTXTFile);

            ReloadCommand.Execute(null);
        }

        #endregion

        #region Virtual functions

        protected override void Load()
        {
            FillUpUserVMs();
        }

        #endregion

        #region General functions

        public void ExportToCSVFile(object o)
        {
            string path = DialogHelper.GetFilePath();

            if (string.IsNullOrEmpty(path))
                return;

            var stringResult = ObjectsToString(",");

            _saver = new CSVSaver();
            string fullPath = _saver.Save(path, stringResult);

            DialogHelper.OpenFolderToDocument(fullPath);
        }

        public void ExportToTXTFile(object o)
        {
            string path = DialogHelper.GetFilePath();

            if (string.IsNullOrEmpty(path))
                return;

            var stringResult = ObjectsToString(" ");

            _saver = new TextSaver();
            string fullPath = _saver.Save(path, stringResult);

            DialogHelper.OpenFolderToDocument(fullPath);
        }

        #endregion

        #region Internal functions

        private void FillUpUserVMs()
        {
            UserVMs.Add(new UserViewModel("Liam", 12, "Las Boyem"));
            UserVMs.Add(new UserViewModel("Olivia", 24, "Merlat"));
            UserVMs.Add(new UserViewModel("Oliver", 8, "Grand"));
            UserVMs.Add(new UserViewModel("Ava", 16, "Santa Linsrai"));
        }

        private string ObjectsToString(string separator)
        {
            var stringBuilder = new StringBuilder();

            foreach (var userVM in SelectedVMs)
            {
                stringBuilder.Append(userVM.Name + separator);
                stringBuilder.Append(userVM.Age + separator);
                stringBuilder.Append(userVM.City);
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}