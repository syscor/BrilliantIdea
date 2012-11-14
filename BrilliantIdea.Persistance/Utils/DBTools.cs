using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BrilliantIdea.Persistance.Model;

namespace BrilliantIdea.Persistance.Utils
{
    public class DBTools
    {
        //ToDo: Organizar para poder reescribir la base de datos en el web config de acuerdo a http://msdn.microsoft.com/en-us/library/bb738533.aspx
        public static void OverrrideConnectionString(string entityConnection)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in xmlDocument.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    var x = xElement.FirstChild.Name;
                    xElement.FirstChild.Attributes[2].Value = entityConnection;
                }
            }

            xmlDocument.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            var xconn = ConfigurationManager.ConnectionStrings.Count;
            var section = ConfigurationManager.GetSection("connectionStrings");

            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString = entityConnection;

            ConfigurationManager.RefreshSection("connectionStrings");

            SysCorEntities sysCor = new SysCorEntities();
            var result = sysCor.Ranges.Select(x => x.Id == 0);
        }
    }
}