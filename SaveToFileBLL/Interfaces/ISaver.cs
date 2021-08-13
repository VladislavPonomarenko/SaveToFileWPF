namespace SaveToFileBLL.Interfaces
{
    public interface ISaver
    {
        string Save(string path, string fileFormat, string data);
    }
}