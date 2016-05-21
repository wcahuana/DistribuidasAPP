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
using System.Windows.Shapes;


namespace WpfApplication3.AREAS.CSANPABLO
{

    public partial class VerContrato : Window
    {
       
        public VerContrato(string nDoc)
        {

            InitializeComponent();
            
        }
        public void cargaDatos(string Doc)
        {
            

        }
        private void SoloNumeros(TextCompositionEventArgs e)
        {

          
        }
     
        private void txtRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
      
        private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        {

        }
        private bool parseaLogin(string rut)
        {

            return true;
        }
        
        private void grillacontrato_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
        private void cmbEspecialidad_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void cmbCentro_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cmbEspecialidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void dtFecha_Loaded(object sender, RoutedEventArgs e)
        {

        }



    }
}
