namespace Logging
{
    public class Actions
    {
        public static bool InfoMethod()
        {
            string msg = "Start method: InfoMethod";
            Logger.GetInstance.Message(Logger.LogType.Info, msg);
            return true;
        }
        public static void WarningMethod()
        {
            throw new BusinessException("Skipped logic in method");
        }
        public static void ErrorMethod()
        {
            throw new Exception("I broke the logic");
        }
    }
}
