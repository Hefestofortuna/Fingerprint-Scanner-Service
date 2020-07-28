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
                if (!FingerprintScannerInfo.Status && DatabaseInfo.Status)
                {
                   //Тягаем функцию без нового пользователя, и вносим записи в бд
                    await Task.Delay(1000);
                }
                else if (FingerprintScannerInfo.Status && DatabaseInfo.Status)
                {
                    //Увидили NOTIFY, добиваем в запись в бд его отпечаток
                    await Task.Delay(5000);
                    FingerprintScannerInfo.Status = false;
                    FingerprintScannerInfo.CanBeRegistered = true;
                }
            }
        }


        public void UpdateStatusServer(object ob)
        {

        }



    }
}
