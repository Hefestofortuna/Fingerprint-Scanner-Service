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

        public void UpdateStatusServer(object ob)
        {
            Acid();
        }

        public async void Acid() 
        {
            Task AcidGetRecordsTask = new Task(()=>AcidGetRecords());
            Task AcidAddPersonTask = new Task(()=> AcidAddPerson("Uri", 2,1));
            Task completedTask = await Task.WhenAny(AcidGetRecordsTask, AcidAddPersonTask);
            if (completedTask == AcidAddPersonTask)
            {
                Console.WriteLine("О, новый чел");
            }
            else
            {
                Console.WriteLine("Ждемс записей");
            }

        }
        //-------------------------Функции которые нужно тягать-------------------------
        public async Task AcidAddPerson(string name, uint id, int pass)
        {

            await Task.Delay(2000);
        }

        public async Task<object[]> AcidGetRecords()
        {
            while (!DatabaseInfo.Status)
            {
                await Task.Delay(2000);
            }
            return new object[] { 1, "20.01.2000 11:00", false };
        }
        //-------------------------Функции которые нужно тягать-------------------------



    }
}
