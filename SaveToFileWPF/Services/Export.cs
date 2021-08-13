using SaveToFileBLL.Interfaces;
using SaveToFileWPF.Helpers;

namespace SaveToFileWPF.Services
{
    public class Export : IExport
    {
        public bool ExportToFile(ISaver saver, string fileFormat, string stringResult)
        {
            string path = DialogHelper.GetFilePath();

            if (string.IsNullOrEmpty(path))
                return false;

            string fullPath = saver.Save(path, fileFormat, stringResult);

            DialogHelper.OpenFolderToDocument(fullPath);

            return true;
        }
    }
}
