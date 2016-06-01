using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Reflection;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using WpfApplication3.AREAS.CLASES_Y_UTILIDADES;

namespace WpfApplication3.AREAS.CEDICSEM
{
    /// <summary>
    /// Interaction logic for PROVIDA_CAMPANAS.xaml
    /// </summary>
    public partial class CEDICSEM : UserControl
    {
        
        public static bool reload = false;
        public CEDICSEM()
        {
            InitializeComponent();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            
        }




        private void IconButtonContractuales_Click(object sender, RoutedEventArgs e)
        {

           
            //traeInfoDatosContractuales(variablebusqueda);
        }


        private void tbx_observacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        

        }
        void traeInfoDatosContractuales(string busqueda)
        {
            
        }

        void traeInfoDatosPersonales(string busqueda)
        {
            
        }
        private void IconButtondatos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpWebRequest req2 = (HttpWebRequest)WebRequest
                  .Create("http://localhost:9805/Bitacora.svc/Bitacoras/"+TxtDocumento.Text);
                req2.Method = "GET";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string clienteJson3 = reader2.ReadToEnd();
                JavaScriptSerializer js3 = new JavaScriptSerializer();
                List<Bitacoras> clienteObtenido = js3.Deserialize<List<Bitacoras>>(clienteJson3);
                grdhistorias.ItemsSource = clienteObtenido;
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                MessageBox.Show(mensaje);
            }
                

        }

        private void cmbnivel1_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        private void cmbnivel1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         

        }

        private void cmbnivel2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
            
        }



        
        private void btnGuardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            
        }

        private void btnVerContratos_Click(object sender, RoutedEventArgs e)
        {
            VerContrato aboutWindow = new VerContrato(TxtDocumento.Text);
            aboutWindow.Show();

        }

        private void btnVerCliente_Click(object sender, RoutedEventArgs e)
        {

        }

    }



}

