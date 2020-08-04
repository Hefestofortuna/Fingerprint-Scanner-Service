namespace Fingerprint_Scanner_Service
{
    interface IObservable
    {
        void RegisterObserver(IObserver o);//Части реализации интерфейса
        void RemoveObserver(IObserver o);//Части реализации интерфейса
        void NotifyObserversAboutConnection();//Части реализации интерфейса
        void NotifyObserversAboutUpdate();//Части реализации интерфейса
    }
}
