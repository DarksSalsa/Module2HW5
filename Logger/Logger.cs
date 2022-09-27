namespace Logging
{
    using Logging.Services;
    using Newtonsoft.Json;
    using System.Text;

    public class Logger
    {
        private static readonly Logger _instance = new();
        private static readonly FileService _fs = new();

        public enum LogType
        {
            Error,
            Warning,
            Info,
        }
        static Logger()
        {
            
        }
        private Logger()
        {
        }
        public static Logger GetInstance
        {
            get
            {
                return _instance;
            }
        }

        public static FileService Fs
        {
            get
            {
                return _fs;
            }
        }

        public void Message(LogType type, string details)
        {
            string constructMessage = $"{DateTime.Now:T}: {type}: {details}";
            Console.WriteLine(constructMessage);
            Fs.WriteLog(constructMessage);
        }

        ~Logger()
        {
            _fs.CloseStreamWriter();
        }
    }
}