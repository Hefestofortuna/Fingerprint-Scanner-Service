using Fingerprint_Scanner_Service.Controllers;

namespace Fingerprint_Scanner_Service
{
    class DatabaseObserver : IObserver //НаблюдаЮЩИЙ объект
    {
        IObservable database;
        Logger logger = new Logger();
        Controller controller = new Controller();
        public DatabaseObserver(IObservable obs)
        {
            database = obs;
            database.RegisterObserver(this);//Регистрация подписки
        }

        public void UpdateStatusFinger(object ob)
        {

        }

        public void UpdateStatusServer(object ob)
        {
            DatabaseInfo dInfo = (DatabaseInfo)ob;
            if (!DatabaseInfo.Status)
            {
                controller.Initialization();
            }
        }

    }
}
