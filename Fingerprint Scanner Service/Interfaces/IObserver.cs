using System;

namespace Fingerprint_Scanner_Service
{
    interface IObserver
    {
        void UpdateStatusServer(Object ob);//Части реализации интерфейса
        void UpdateStatusFinger(Object ob);//Части реализации интерфейса
    }
}
