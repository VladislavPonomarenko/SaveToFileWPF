using System.Diagnostics;
using System.Windows.Forms;

namespace SaveToFileWPF.Helpers
{
    public static class DialogHelper
    {
        public static string GetFilePath()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
                else
                    return string.Empty;
            }
        }

        public static void OpenFolderToDocument(string path)
        {
            string argument = "/select, \"" + path + "\"";
            Process.Start("explorer.exe", argument);
        }
    }
}
