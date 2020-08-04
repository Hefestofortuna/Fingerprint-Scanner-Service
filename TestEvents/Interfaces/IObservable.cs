using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvents
{
    interface IObservable
    {
        void RegisterObserver(IObserver o);//Части реализации интерфейса
        void RemoveObserver(IObserver o);//Части реализации интерфейса
        void NotifyObserversAboutConnection();//Части реализации интерфейса
        void NotifyObserversAboutUpdate();//Части реализации интерфейса
    }
}
