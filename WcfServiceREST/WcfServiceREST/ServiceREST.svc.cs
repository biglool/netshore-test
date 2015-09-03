using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;


namespace WcfServiceREST
{
   
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ServiceREST : IServiceREST
    {
        private string fitxeractHerois = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SuperHeroes.dat";

        public List<heroi> json()
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
                throw new FaultException("F***K :S " + ex.ToString());
            }
            return llistaerois;

        }

      
    }
}
