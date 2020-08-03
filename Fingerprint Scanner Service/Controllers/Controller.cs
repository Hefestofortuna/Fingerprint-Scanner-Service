using System.Threading.Tasks;

namespace Fingerprint_Scanner_Service.Controllers
{
    class Controller
    {
        public void Initialization()
        {
            Database database = new Database();
            DatabaseObserver observer = new DatabaseObserver(database);
            FingerprintScanner fingerprint = new FingerprintScanner(database);
            Task.Run(() => database.onDatabaseConnection());
            Task.Run(() => fingerprint.Acid());
        }
    }
}
