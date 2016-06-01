using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RESTServices.Dominio;
using RESTServices.Persistencia;

namespace RESTServices
{
    public class Proveedores : IProveedores
    {
        private ProveedorDAO dao = new ProveedorDAO();

        public Proveedor CrearProveedor(Proveedor proveedorACrear)
        {
            if ("10450963041".Equals(proveedorACrear.Ruc))
            {
                throw new WebFaultException<string>("Alumno ya existente", HttpStatusCode.Conflict);
            }

            return dao.Crear(proveedorACrear);
        }

        public Proveedor ObtenerProveedor(string ruc)
        {
            return dao.Obtener(ruc);
        }

        public Proveedor ModificarProveedor(Proveedor proveedorAModificar)
        {
            if ("20523131231".Equals(proveedorAModificar.Ruc) && "La Casita SA".Equals(proveedorAModificar.RazonSocial))
            {
                throw new WebFaultException<string>("No cambio la razon social", HttpStatusCode.NotModified);
            }

            return dao.Modificar(proveedorAModificar);
        }

        public void EliminarProveedor(string ruc)
        {
            dao.Eliminar(ruc);
        }

        public List<Proveedor> ListarProveedores()
        {
            return dao.ListarTodos();
        }
    }
}
