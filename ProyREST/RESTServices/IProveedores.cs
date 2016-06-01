using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RESTServices.Dominio;

namespace RESTServices
{
    [ServiceContract]
    public interface IProveedores
    {
        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate="Proveedores", ResponseFormat=WebMessageFormat.Json)]
        Proveedor CrearProveedor(Proveedor proveedorACrear);
        
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Proveedores/{ruc}", ResponseFormat = WebMessageFormat.Json)]
        Proveedor ObtenerProveedor(string ruc);
        
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Proveedores", ResponseFormat = WebMessageFormat.Json)]
        Proveedor ModificarProveedor(Proveedor proveedorAModificar);
        
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Proveedores/{ruc}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarProveedor(string ruc);
        
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Proveedores", ResponseFormat = WebMessageFormat.Json)]
        List<Proveedor> ListarProveedores();
    }
}
