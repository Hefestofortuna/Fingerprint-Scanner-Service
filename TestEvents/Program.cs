using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestEvents.Controllers;

namespace TestEvents
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Initialization();
            Console.ReadLine();
        }
    }
}
