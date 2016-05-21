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

namespace WpfApplication3.AREAS.CSANPABLO
{
    /// <summary>
    /// Interaction logic for PROVIDA_CAMPANAS.xaml
    /// </summary>
    public partial class CSANPABLO_custom : UserControl
    {
        
        public static bool reload = false;
        public CSANPABLO_custom()
        {
            InitializeComponent();
            //if (reload == true)
            //{

            //}

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

    }



}

