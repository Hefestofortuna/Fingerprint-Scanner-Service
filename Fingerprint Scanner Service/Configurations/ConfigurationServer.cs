using System;
using System.Collections.Generic;
using System.Xml;

namespace Fingerprint_Scanner_Service.Configurations
{
    class ConfigurationServer
    {
        public List<string> connectionString()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Environment.CurrentDirectory+ @"\DatabaseServerSetup.xml");
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
