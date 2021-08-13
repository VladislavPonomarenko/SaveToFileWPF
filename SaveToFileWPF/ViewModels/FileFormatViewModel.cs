using SaveToFileWPF.Commands;
using System;

namespace SaveToFileWPF.ViewModels
{
    public class FileFormatViewModel
    {
        public string Title { get; }
        public string FileFormat { get; }

        public Action<FileFormatViewModel> SaveToFile { get; }

        public RelayCommand ExportToFileCommand { get; set; }

        public FileFormatViewModel(string title, string fileFormat, Action<FileFormatViewModel> saveToFile)
        {
            Title = title;
            FileFormat = fileFormat;
            SaveToFile = saveToFile;

            ExportToFileCommand = new RelayCommand(Save);
        }

        private void Save(object o)
        {
            SaveToFile?.Invoke(this);
        }
    }
}