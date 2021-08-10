using SaveToFileBLL.Helpers;
using SaveToFileBLL.Interfaces;

namespace SaveToFileBLL.Services
{
    public class TextSaver : ISaver
    {
        public string Save(string path, string data)
        {
            string fullPath = path + @"\TXTFile.txt";

            FileHelper.SaveFile(fullPath, data);

            return fullPath;
        }
    }
}