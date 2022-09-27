namespace Logging
{
    public class Config
    {
        public FilePath PathToFile { get; set; }
    }

    public class FilePath
    {
        public string Path { get; set; }
        public string FileExtension { get; set; }
    }
}
