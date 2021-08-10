using SaveToFileBLL.Helpers;
using SaveToFileBLL.Interfaces;

namespace SaveToFileBLL.Services
{
    public class CSVSaver : ISaver
    {
        public string Save(string path, string data)
        {
            string fullPath = path + @"\CSVFile.csv";

            FileHelper.SaveFile(fullPath, data);

            return fullPath;
        }
    }
}