using Newtonsoft.Json;
using System.Text;

namespace Logging.Services
{
    public class FileService
    {
        private readonly StreamWriter _sw;

        public FileService()
        {
            FilePathCheckAndCreateAndDelete();
            _sw = new(CreateFileName(), true);
        }

        private StreamWriter Sw { get { return _sw; } }
        private static Config FilePathSerialization()
        {
            var configFile = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            return config;
        }

        public static void FilePathCheckAndCreateAndDelete()
        {
            var info = FileService.FilePathSerialization();
            if (info == null)
            {
                throw new NullReferenceException("Path is null");
            }
            else if (!Directory.Exists(info.PathToFile.Path))
            {
                Directory.CreateDirectory(info.PathToFile.Path);
            }
            DirectoryInfo dir = new(info.PathToFile.Path);
            var fileList = dir.GetFileSystemInfos();
            FileSystemInfo[] sortedFileList = fileList.OrderBy(f => f.CreationTime).ToArray();
            if (sortedFileList.Length > 3)
            {
                sortedFileList.First().Delete();
            }
        }

        public static string CreateFileName()
        {
            var info = FileService.FilePathSerialization();
            var fileName = $"{info.PathToFile.Path}{DateTime.Now:hh.mm.ss dd.MM.yyyy}{info.PathToFile.FileExtension}";
            return fileName;
            
        }

        public void WriteLog(string msg)
        {
                Sw.WriteLine(msg); 
        }

        public void CloseStreamWriter()
        {
            _sw.Close();
        }
    }
}
