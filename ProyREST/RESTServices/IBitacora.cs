using RESTServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBitacora" in both code and config file together.
    [ServiceContract]
    public interface IBitacora
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Bitacoras", ResponseFormat = WebMessageFormat.Json)]
        Bitacoras InsertarBitacora(Bitacoras bitacoraACrear);

        [OperationContract]
       [WebInvoke(Method = "GET", UriTemplate = "Bitacoras/{DNI}", ResponseFormat = WebMessageFormat.Json)]
        List<Bitacoras> ObtenerBitacoras(string DNI);
    }
}
