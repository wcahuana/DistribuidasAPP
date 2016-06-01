using RESTServices.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFCliente.Dominio;

namespace RESTServices.Persistencia
{
    public class BitacoraDAO
    {
        public Bitacoras RegistrarBitacora(Bitacoras proveedorACrear)
        {
            
            Bitacoras proveedorErroneo = null;
            bool estado = false;
            String nombreProcedimiento = "[XIUX_CEDICSEM_INSERTA_TIPIFICACION]";

            SqlParameter[] parameter = {
              new SqlParameter("@CSANPABLO_T_CONNID",proveedorACrear.DNI),
              new SqlParameter("@CSANPABLO_T_ANI",proveedorACrear.Origen),
              new SqlParameter("@CSANPABLO_T_DNIS",proveedorACrear.Destino),
              new SqlParameter("@CSANPABLO_T_HORA_IN_LLAMADA",proveedorACrear.FechaInicioCall),
              new SqlParameter("@CSANPABLO_T_HORA_OUT_LLAMADA",proveedorACrear.FechaTerminoCall),
              new SqlParameter("@CSANPABLO_T_DURACION_LLAMADA",proveedorACrear.FechaInicioCall),
              new SqlParameter("@CSANPABLO_T_AGENTE",proveedorACrear.Agente),
              new SqlParameter("@CSANPABLO_T_TIPO_INTERACCION",proveedorACrear.TipoInteraccion),
              new SqlParameter("@CSANPABLO_T_NOMBRE_CAMP",proveedorACrear.NombreCamp),
              new SqlParameter("@CSANPABLO_T_cmbEfectividad",proveedorACrear.Efectividad),
              new SqlParameter("@CSANPABLO_T_cmbAccion",proveedorACrear.Accion),
              new SqlParameter("@CSANPABLO_T_cmbMotivos",proveedorACrear.Motivo),
              new SqlParameter("@CSANPABLO_T_OBSERVACIONES",proveedorACrear.Observaciones),
              new SqlParameter("@CSANPABLO_T_ESTADOINTERACCION",proveedorACrear.TipoInteraccion),
              new SqlParameter("@CSANPABLO_T_ESTADOTIPIFICACION",proveedorACrear.TipoInteraccion),  
              new SqlParameter("@CSANPABLO_T_FECHAACCION",proveedorACrear.FechaAccion),
              new SqlParameter("@CSANPABLO_T_PREVCONNID",proveedorACrear.DNI)
            };
            try
            {
                estado = SqlHelper.executeProcedure(nombreProcedimiento, parameter);
                return proveedorACrear;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return proveedorErroneo;
                throw;

            }
            
            
        }


        public List<Bitacoras> ConsultarBitacora(string DNI){
            String sql = "";
            DataTable datos;
           

            
            List<Bitacoras> bitacorasEncontrados = new List<Bitacoras>();
            Bitacoras bitacoraEncontrada = null;
            sql += "exec [SXXX_EDICSEM_HISTORIAL] @Documento";
                                
            using (SqlConnection con = new SqlConnection(SqlHelper.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            bitacoraEncontrada = new Bitacoras()
                            {
                                ID = (string)resultado["ID"],
                                DNI = (string)resultado["CEDICSEM_C_TxtDocumento"],
                                FechaInicioCall = (string)resultado["FECHA"],
                                FechaTerminoCall = (string)resultado["HORA"],
                                Agente = (string)resultado["AGENTE"],
                                Accion = (string)resultado["Combos"],
                                Observaciones = (string)resultado["Observaciones"]
                            };
                            bitacorasEncontrados.Add(bitacoraEncontrada);
                        }
                    }
                }
            }
            return bitacorasEncontrados;
        }
    }
}