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
        public void InsertarBitacoraOk()
        {
            
           
              //pRUEBA DE CREACION DE CLIENTE via HTTP POST   
            string postData = "{\"DNI\":\"11112222\",\"Destino\":\"12443\",\"FechaInicioCall\":\"121\",\"FechaTerminoCall\":\"xxxxxx\",\"DuracionCall\":\"xxxxxx\",\"Agente\":\"xxxxxx\",\"TipoInteraccion\":\"xxxxxx\",\"NombreCamp\":\"xxxxxx\",\"Accion\":\"xxxxxx\",\"FechaAccion\":\"xxxxxx\",\"Origen\":\"xxxxxx\",\"Observaciones\":\"xxxxxx\",\"Motivo\":\"xxxxxx\",\"Efectividad\":\"xxxxxx\",\"ID\":\"xxxxxx\"}"; //JSON

              byte[] data = Encoding.UTF8.GetBytes(postData);
              HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Bitacora.svc/Bitacoras");

              req.Method = "POST";
              req.ContentLength = data.Length ; 
              req.ContentType = "application/json";

              var reqStream = req.GetRequestStream();
              reqStream.Write(data, 0, data.Length);

              var res = (HttpWebResponse)req.GetResponse();
              StreamReader reader = new StreamReader(res.GetResponseStream());
              string bitacoraJson = reader.ReadToEnd();
              JavaScriptSerializer js= new JavaScriptSerializer();

              Bitacoras bitacoraCreada = js.Deserialize<Bitacoras>(bitacoraJson);
              Assert.AreEqual("11112222", bitacoraCreada.DNI);
             


        }

        [TestMethod]
        public void InsertarBitacoraKO()
        { 
            try
            {
                string postData = "{\"DNI\":\"123\",\"Destino\":\"12443\",\"FechaInicioCall\":\"121\",\"FechaTerminoCall\":\"xxxxxx\",\"DuracionCall\":\"xxxxxx\",\"Agente\":\"xxxxxx\",\"TipoInteraccion\":\"xxxxxx\",\"NombreCamp\":\"xxxxxx\",\"Accion\":\"xxxxxx\",\"FechaAccion\":\"xxxxxx\",\"Origen\":\"xxxxxx\",\"Observaciones\":\"xxxxxx\",\"Motivo\":\"xxxxxx\",\"Efectividad\":\"xxxxxx\",\"ID\":\"xxxxxx\"}"; //JSON

                byte[] data = Encoding.UTF8.GetBytes(postData);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Bitacora.svc/Bitacoras");

                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";

                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string bitacoraJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();

                Bitacoras bitacoraCreada = js.Deserialize<Bitacoras>(bitacoraJson);
                Assert.AreEqual("123", bitacoraCreada.DNI);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("El DNI tiene que ser de 8 Digitos", mensaje);
            }




        }

        
        [TestMethod]

        public void ListarBitacora()
        {
            
              HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create("http://localhost:9805/Bitacora.svc/Bitacoras/07954988");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string clienteJson3 = reader2.ReadToEnd();
            JavaScriptSerializer js3 = new JavaScriptSerializer();
            List<Bitacoras> clienteObtenido = js3.Deserialize<List<Bitacoras>>(clienteJson3);
            Assert.AreEqual("07954988", clienteObtenido[0].DNI);
        }

        [TestMethod]
        public void ListarNoExiste()
        {
            try
            {
                HttpWebRequest req2 = (HttpWebRequest)WebRequest
                  .Create("http://localhost:9805/Bitacora.svc/Bitacoras/1234");
                req2.Method = "GET";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string clienteJson3 = reader2.ReadToEnd();
                JavaScriptSerializer js3 = new JavaScriptSerializer();
                List<Bitacoras> clienteObtenido = js3.Deserialize<List<Bitacoras>>(clienteJson3);
                Assert.AreEqual("1234", clienteObtenido[0].DNI);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("No se encontraron Datos", mensaje);
            }
        }
        




    }
}
