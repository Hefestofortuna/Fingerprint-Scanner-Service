using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvents
{
    interface IObserver
    {
        void UpdateStatusServer(Object ob);//Части реализации интерфейса
        void UpdateStatusFinger(Object ob);//Части реализации интерфейса
    }
}
