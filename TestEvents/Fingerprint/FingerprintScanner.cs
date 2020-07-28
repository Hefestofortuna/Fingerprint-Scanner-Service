using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestEvents
{
    class FingerprintScanner : IObserver //НаблюдаЮЩИЙ объект
    {
        IObservable database;
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
                    var delay = getAcid();
                    var reaction = setAcid();

                    Task completedTask = await Task.WhenAny(delay, reaction);

                    if (completedTask == delay)
                    {
                        try { delay.Dispose(); } catch { }
                        await Task.Delay(1000);
                        Console.WriteLine("У. ВАУ. НОВЫЙ ЧУВАЧОК");
                    }
                    else
                    {
                        try { reaction.Dispose(); } catch { }
                        await Task.Delay(1000);
                        Console.WriteLine("НОВЫХ НЕТ ИЩЕМ СТАРЫХ");
                    }
                }
                
            }
        }

        public static async Task getAcid()
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
