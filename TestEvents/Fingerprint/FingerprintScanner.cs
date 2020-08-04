using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            FingerprintScannerInfo fInfo = (FingerprintScannerInfo)ob;
            FingerprintScannerInfo.Status = true;
            /*
            if (FingerprintScannerInfo.Status)
            {
                using (var task = AcidAddPerson("Uri Gagarin", 1, 349013))
                {
                    task.Start();
                    Task.WaitAll(task);
                }
            Task task = new Task(() => AcidAddPerson("Uri Gagarin", 1, 349013));
               task.Wait();
            }
            else
            {
                while (!FingerprintScannerInfo.Status)
                {
                    using (var task = AcidGetRecords())
                    {
                        task.Start();
                        Task.WaitAll(task);
                    }
                }
                
            }*/
        }

        public void UpdateStatusServer(object ob)
        {
            
            DatabaseInfo dInfo = (DatabaseInfo)ob;
            if (DatabaseInfo.Status)
            {
                Console.WriteLine("Отпечаток пальца будет считан");
            }
        }
        //-------------------------Функции которые нужно тягать-------------------------
        public async Task AcidAddPerson(string name, uint id, int pass)
        {
            await Task.Delay(2000);
        }

        public async Task<object[]> AcidGetRecords()
        {
            await Task.Delay(2000);
            return new object[] { 1, "20.01.2000 11:00", false };
        }
        //-------------------------Функции которые нужно тягать-------------------------
    }
}
