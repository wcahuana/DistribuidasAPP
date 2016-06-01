using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RESTTests
{
    [TestClass]
    public class ProveedoresTest
    {
        [TestMethod]
        public void T1_CrearOK()
        {
            string postdata = "{\"Ruc\":\"20523131231\",\"Tipo\":\"Jurídica\",\"RazonSocial\":\"La Casita SA\",\"Telefono\":\"5323536\",\"Email\":\"sac@lacasita.com.pe\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Proveedores.svc/Proveedores");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string proveedorJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Proveedor proveedorCreado = js.Deserialize<Proveedor>(proveedorJson);
            Assert.AreEqual("20523131231", proveedorCreado.Ruc);
            Assert.AreEqual("Jurídica", proveedorCreado.Tipo);
            Assert.AreEqual("La Casita SA", proveedorCreado.RazonSocial);
            Assert.AreEqual("5323536", proveedorCreado.Telefono);
            Assert.AreEqual("sac@lacasita.com.pe", proveedorCreado.Email);

            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Proveedores.svc/Proveedores/20523131231");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string proveedorJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Proveedor proveedorObtenido = js2.Deserialize<Proveedor>(proveedorJson2);
            Assert.AreEqual("20523131231", proveedorObtenido.Ruc);
            Assert.AreEqual("Jurídica", proveedorObtenido.Tipo);
            Assert.AreEqual("La Casita SA", proveedorObtenido.RazonSocial);
            Assert.AreEqual("5323536", proveedorObtenido.Telefono);
            Assert.AreEqual("sac@lacasita.com.pe", proveedorObtenido.Email);
        }

        [TestMethod]
        public void T2_CrearError()
        {
            string postdata = "{\"Ruc\":\"10450963041\",\"Tipo\":\"Jurídica\",\"RazonSocial\":\"La Casita SA\",\"Telefono\":\"5323536\",\"Email\":\"sac@lacasita.com.pe\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Proveedores.svc/Proveedores");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string proveedorJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Proveedor proveedorCreado = js.Deserialize<Proveedor>(proveedorJson);
                Assert.AreEqual("10450963041", proveedorCreado.Ruc);
                Assert.AreEqual("Jurídica", proveedorCreado.Tipo);
                Assert.AreEqual("La Casita SA", proveedorCreado.RazonSocial);
                Assert.AreEqual("5323536", proveedorCreado.Telefono);
                Assert.AreEqual("sac@lacasita.com.pe", proveedorCreado.Email);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Alumno ya existente", mensaje);
            }
        }

        [TestMethod]
        public void T3_ModificarOK()
        {
            string postdata = "{\"Ruc\":\"20523131231\",\"Tipo\":\"Jurídica\",\"RazonSocial\":\"La Casona SA\",\"Telefono\":\"955334542\",\"Email\":\"sac@lacasona.com.pe\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Proveedores.svc/Proveedores");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string proveedorJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Proveedor proveedorModificado = js.Deserialize<Proveedor>(proveedorJson);
            Assert.AreEqual("20523131231", proveedorModificado.Ruc);
            Assert.AreEqual("Jurídica", proveedorModificado.Tipo);
            Assert.AreEqual("La Casona SA", proveedorModificado.RazonSocial);
            Assert.AreEqual("955334542", proveedorModificado.Telefono);
            Assert.AreEqual("sac@lacasona.com.pe", proveedorModificado.Email);

            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Proveedores.svc/Proveedores/20523131231");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string proveedorJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Proveedor proveedorObtenido = js2.Deserialize<Proveedor>(proveedorJson2);
            Assert.AreEqual("20523131231", proveedorObtenido.Ruc);
            Assert.AreEqual("Jurídica", proveedorObtenido.Tipo);
            Assert.AreEqual("La Casona SA", proveedorObtenido.RazonSocial);
            Assert.AreEqual("955334542", proveedorObtenido.Telefono);
            Assert.AreEqual("sac@lacasona.com.pe", proveedorObtenido.Email);
        }

        [TestMethod]
        public void T4_ModificarError()
        {
            string postdata = "{\"Ruc\":\"20523131231\",\"Tipo\":\"Jurídica\",\"RazonSocial\":\"La Casita SA\",\"Telefono\":\"955334542\",\"Email\":\"sac@lacasona.com.pe\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Proveedores.svc/Proveedores");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string proveedorJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Proveedor proveedorModificado = js.Deserialize<Proveedor>(proveedorJson);
                Assert.AreEqual("20523131231", proveedorModificado.Ruc);
                Assert.AreEqual("Jurídica", proveedorModificado.Tipo);
                Assert.AreEqual("La Casita SA", proveedorModificado.RazonSocial);
                Assert.AreEqual("955334542", proveedorModificado.Telefono);
                Assert.AreEqual("sac@lacasona.com.pe", proveedorModificado.Email);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("No cambio la razon social", mensaje);
            }
        }

        [TestMethod]
        public void T5_Eliminar()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Proveedores.svc/Proveedores/20523131231");
            req.Method = "DELETE";
            req.GetResponse();
            try
            {
                HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:9805/Proveedores.svc/Proveedores/20523131231");
                req2.Method = "GET";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string proveedorJson2 = reader2.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Proveedor proveedorObtenido = js2.Deserialize<Proveedor>(proveedorJson2);
                Assert.AreEqual("", proveedorObtenido.Ruc);
                Assert.AreEqual("", proveedorObtenido.Tipo);
                Assert.AreEqual("", proveedorObtenido.RazonSocial);
                Assert.AreEqual("", proveedorObtenido.Telefono);
                Assert.AreEqual("", proveedorObtenido.Email);
            }
            catch (Exception e)
            {
                string mensaje = "No se encuentra el ruc";
                Assert.AreEqual("No se encuentra el ruc", mensaje);
            }
        }
    }
}
