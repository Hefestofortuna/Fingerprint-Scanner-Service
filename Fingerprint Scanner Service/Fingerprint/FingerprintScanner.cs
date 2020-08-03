using System;
using System.Threading.Tasks;

namespace Fingerprint_Scanner_Service
{
    class FingerprintScanner : IObserver //НаблюдаЮЩИЙ объект
    {
        IObservable database;
        Logger logger = new Logger();

        public FingerprintScanner(IObservable obs)
        {
            database = obs;
            database.RegisterObserver(this);//Регистрация подписки
        }

        public void UpdateStatusFinger(object ob)
        {
            FingerprintScannerInfo.Status = true;
        }

        async public void Acid()
        {
            while (true)
            {
                if (DatabaseInfo.Status)
                {
                    var delay = GetAcid();
                    var reaction = setAcid();

                    Task completedTask = await Task.WhenAny(delay, reaction);

                    if (completedTask == delay)
                    {
                        try { delay.Dispose(); } catch { }
                        await Task.Delay(1000); 
                        logger.CreateLoggerFile("Adding a new user");
                    }
                    else
                    {
                        try { reaction.Dispose(); } catch { }
                        await Task.Delay(1000);
                    }
                }

            }
        }

        public static async Task GetAcid()
        {
            if (!FingerprintScannerInfo.Status && DatabaseInfo.Status)
            {
                //Тягаем функцию без нового пользователя, и вносим записи в бд
            }
        }

        public static async Task setAcid()
        {
            if (FingerprintScannerInfo.Status && DatabaseInfo.Status)
            {
                FingerprintScannerInfo.Status = false;
                FingerprintScannerInfo.CanBeRegistered = true;
            }
        }


        public void UpdateStatusServer(object ob)
        {

        }
    }
}
