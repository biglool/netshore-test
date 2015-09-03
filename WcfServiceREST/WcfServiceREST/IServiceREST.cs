
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace WcfServiceREST
{
    // url test http://localhost:59945/ServiceREST.svc/herois
    [ServiceContract]
    public interface IServiceREST
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "herois")]
         List<heroi> json();
    }

    // una mica de format
    [DataContract(Name = "Heroi")]
    public class heroi
    {
        [DataMember(Name = "Nom")]
        internal string nom;
        public heroi(string nouNom)
        {
            if (nouNom == null) nom = "";
            else nom = nouNom;
        }
    }
}
