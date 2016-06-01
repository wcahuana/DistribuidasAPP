using RESTServices.Dominio;
using RESTServices.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Bitacora" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Bitacora.svc or Bitacora.svc.cs at the Solution Explorer and start debugging.
    public class Bitacora : IBitacora
    {
        private BitacoraDAO bitacoraDAO = new BitacoraDAO();
        public List<Bitacoras> ObtenerBitacoras(string DNI)
        {
            List<Bitacoras> resultado = new List<Bitacoras>();
            resultado = bitacoraDAO.ConsultarBitacora(DNI);
            if(resultado.Count <= 0){
                throw new WebFaultException<string>("No se encontraron Datos", HttpStatusCode.NotFound);
            }else{
                return resultado;
            }
            

        }

        public Bitacoras InsertarBitacora(Bitacoras bitacoraACrear)
        {
            Bitacoras resultado = bitacoraDAO.RegistrarBitacora(bitacoraACrear);
            if(resultado == null){

                throw new WebFaultException<string>("Se ha encontrado un error", HttpStatusCode.InternalServerError);
            }
            else if(bitacoraACrear.DNI.Length != 8){
                throw new WebFaultException<string>("El DNI tiene que ser de 8 Digitos", HttpStatusCode.LengthRequired);
            }
            else
            {
                return resultado;
            }
        }
    }
}
