﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEvents.Controllers;

namespace TestEvents
{
    class Observer : IObserver //НаблюдаЮЩИЙ объект
    {
        IObservable database;
        Logger logger = new Logger();
        Controller controller = new Controller();
        public Observer(IObservable obs)
        {
            database = obs;
            database.RegisterObserver(this);//Регистрация подписки
        }

        public void UpdateStatusFinger(object ob)
        {
        }

        async public void UpdateStatusServer(object ob)
        {
            DatabaseInfo dInfo = (DatabaseInfo)ob;
            if (!DatabaseInfo.Status)
            {
                await Task.Run(() => controller.Initialization());
            }
        }

    }
   
}
