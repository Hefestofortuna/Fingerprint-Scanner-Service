using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestEvents.Configurations
{
    class ConfigurationServer
    {
        public List<string> connectionString()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\karatui\Documents\GitHub\Fingerprint-Scanner-Service\TestEvents\Configurations\DatabaseServerSetup.xml");
            XmlElement document = xml.DocumentElement;
            List<string> parameters = new List<string>(); 
            foreach (XmlNode xnode in document)
            {
                foreach (XmlNode chilnode in xnode.ChildNodes)
                {
                    parameters.Add(chilnode.InnerText);
                }
            }
            return parameters;
        }
    }
}
