using SaveToFileBLL.Helpers;
using SaveToFileBLL.Interfaces;

namespace SaveToFileBLL.Services
{
    public class Saver : ISaver
    {
        public string Save(string path, string fileFormat, string data)
        {
            string fileName = fileFormat.ToUpper() + "File." + fileFormat.ToLower();

            string fullPath = path + @"\" + fileName;

            FileHelper.SaveFile(fullPath, data);

            return fullPath;
        }
    }
}
