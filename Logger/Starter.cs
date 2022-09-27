namespace Logging
{
    public class Starter
    {
        public static void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                //Comment to remove the pause(used for showing the difference)
                System.Threading.Thread.Sleep(1000);
                try
                {

                    switch (Random.Shared.Next(1, 4))
                    {
                        case 1:
                            Actions.InfoMethod();
                            break;
                        case 2:
                            Actions.WarningMethod();
                            break;
                        case 3:
                            Actions.ErrorMethod();
                            break;
                        default:
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    string msg = $"Logger got this custom exception: {ex.Message}";
                    Logger.GetInstance.Message(Logger.LogType.Warning, msg);
                }
                catch (Exception ex)
                {
                    string msg = $"Action failed by reason: {ex}";
                    Logger.GetInstance.Message(Logger.LogType.Error, msg);
                }
            }
        }
    }
}