namespace SaveToFileBLL.Interfaces
{
    public interface IExport
    {
        bool ExportToFile(ISaver saver, string fileFormat, string stringResult);
    }
}
