using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTTests
{
    /// <summary>
    /// Descripción resumida de BitacorasTest
    /// </summary>
    [TestClass]
    public class BitacorasTest
    {

        [TestMethod]
        public void RegistrarOk()
        {
            /*              new SqlParameter("@CSANPABLO_T_CONNID",proveedorACrear.DNI),
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
              new SqlParameter("@CSANPABLO_T_PREVCONNID",proveedorACrear.DNI)*/

           
              //pRUEBA DE CREACION DE CLIENTE via HTTP POST   
            string postData = "{\"CSANPABLO_T_CONNID\":\"11112222\",\"CSANPABLO_T_ANI\":\"Juan\",\"CSANPABLO_T_DNIS\":\"Perez\",\"CSANPABLO_T_HORA_IN_LLAMADA\":\"xxxxxx\" " +
                              " ,\"CSANPABLO_T_HORA_OUT_LLAMADA\":\"xxxxxx\",\"CSANPABLO_T_DURACION_LLAMADA\":\"xxxxxx\",\"CSANPABLO_T_AGENTE\":\"xxxxxx\" "+
                              " ,\"CSANPABLO_T_TIPO_INTERACCION\":\"xxxxxx\",\"CSANPABLO_T_NOMBRE_CAMP\":\"xxxxxx\",\"CSANPABLO_T_cmbEfectividad\":\"xxxxxx\" " +
                              " ,\"CSANPABLO_T_cmbAccion\":\"xxxxxx\",\"CSANPABLO_T_cmbMotivos\":\"xxxxxx\",\"CSANPABLO_T_OBSERVACIONES\":\"xxxxxx\" " +
                              " ,\"CSANPABLO_T_ESTADOINTERACCION\":\"xxxxxx\",\"CSANPABLO_T_ESTADOTIPIFICACION\":\"xxxxxx\" "+
                              " ,\"CSANPABLO_T_FECHAACCION\":\"xxxxxx\",\"CSANPABLO_T_PREVCONNID\":\"xxxxxx\"}"; //JSON

              byte[] data = Encoding.UTF8.GetBytes(postData);
              HttpWebRequest req = (HttpWebRequest)WebRequest
                  .Create("http://localhost:9805/Bitacora.svc/Bitacoras");

              req.Method = "POST";
              req.ContentLength = data.Length ; 
              req.ContentType = "application/json";

              var reqStream = req.GetRequestStream();
              reqStream.Write(data, 0, data.Length);

              var res = (HttpWebResponse)req.GetResponse();
              StreamReader reader = new StreamReader(res.GetResponseStream());
              string bitacoraJson = reader.ReadToEnd();
              JavaScriptSerializer js= new JavaScriptSerializer();

              Bitacora bitacoraCreada = js.Deserialize<Bitacora>(bitacoraJson);
              Assert.AreEqual("11112222", bitacoraCreada.DNI);
              Assert.AreEqual("xxxxxx", bitacoraCreada.Origen);
              Assert.AreEqual("xxxxxx", bitacoraCreada.Destino);
              Assert.AreEqual("xxxxxx", bitacoraCreada.FechaInicioCall);
              Assert.AreEqual("xxxxxx", bitacoraCreada.FechaTerminoCall);
              Assert.AreEqual("xxxxxx", bitacoraCreada.FechaInicioCall);
              Assert.AreEqual("xxxxxx", bitacoraCreada.Agente);
              Assert.AreEqual("xxxxxx", bitacoraCreada.TipoInteraccion);
              Assert.AreEqual("xxxxxx", bitacoraCreada.NombreCamp);
              Assert.AreEqual("xxxxxx", bitacoraCreada.Efectividad);
              Assert.AreEqual("xxxxxx", bitacoraCreada.Accion);
              Assert.AreEqual("xxxxxx", bitacoraCreada.Motivo);
              Assert.AreEqual("xxxxxx", bitacoraCreada.Observaciones);
              Assert.AreEqual("xxxxxx", bitacoraCreada.TipoInteraccion);
              Assert.AreEqual("xxxxxx", bitacoraCreada.TipoInteraccion);
              Assert.AreEqual("xxxxxx", bitacoraCreada.FechaAccion);
              Assert.AreEqual("xxxxxx", bitacoraCreada.DNI);


        }

        
        [TestMethod]

        public void ListarBitacora()
        {
            
              HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:9805/Bitacora.svc/Bitacoras");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string clienteJson3 = reader2.ReadToEnd();
            JavaScriptSerializer js3 = new JavaScriptSerializer();
            List<Bitacora> clienteObtenido = js3.Deserialize<List<Bitacora>>(clienteJson3);
            Assert.AreEqual("001105238", clienteObtenido[0].ID);
        }
        




    }
}
