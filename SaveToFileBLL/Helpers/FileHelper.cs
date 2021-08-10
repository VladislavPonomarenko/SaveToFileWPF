using System.IO;

namespace SaveToFileBLL.Helpers
{
    public static class FileHelper
    {
        public static void SaveFile(string path, string data)
        {
            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllTextAsync(path, data);
        }
    }
}