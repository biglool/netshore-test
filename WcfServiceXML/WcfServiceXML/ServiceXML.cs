using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceXML
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServiceXML : IServiceXML
    {
        private string fitxeractHerois = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SuperHeroes.dat";

        public List<heroi> Herois()
        {
            return omplellista(fitxeractHerois);
        }

        private List<heroi> omplellista(string fitxer)
        {
            List<heroi> llistaerois = new List<heroi>();
            try
            {
                using (StreamReader sr = new StreamReader(fitxer))
                {
                    while (sr.Peek() >= 0)
                    {
                        llistaerois.Add(new heroi(sr.ReadLine()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Cagada :( " + ex.ToString());
            }
            return llistaerois;

        }
    }
}
