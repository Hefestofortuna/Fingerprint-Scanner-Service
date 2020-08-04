using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvents.Controllers
{
    class Controller
    {
        public void Initialization()
        {
            Database database = new Database();
            Observer observer = new Observer(database);
            FingerprintScanner fingerprint = new FingerprintScanner(database);
            database.onDatabaseConnection();
        }
    }
}
