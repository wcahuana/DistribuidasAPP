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
using Genesyslab.Desktop.Modules.InteractionExtensionSample.AREAS.CLASES_Y_UTILIDADES;
using System.Windows.Controls.Primitives;
using System.Data;


namespace Genesyslab.Desktop.Modules.InteractionExtensionSample.AREAS.SALUD
{
    /// <summary>
    /// Interaction logic for Relevantes.xaml
    /// </summary>
    public partial class GestionHoras : Window
    {
        Clientes oUsr = new Clientes();

        public GestionHoras()
        {
            InitializeComponent();
        }
        //Metodo que obliga a campo a solamente escribir solo numeros
        private void SoloNumeros(TextCompositionEventArgs e)
        {

            //se convierte a Ascci del la tecla presionada
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            // verificamos que se encuentre en ese rango que son entre el 0 y el 9
            if ((ascci >= 48 && ascci <= 57) || ascci == 75 || ascci == 107)
                e.Handled = false;
            else
                e.Handled = true;
        }
        //Metodo que se ejecuta antes de posicionarse sobre el control. llama al metodo solo numeros.
        private void txtRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumeros(e);
        }
        //Metodo ejecutado al posicionarse sobre control.Resetea el rut, y elimina puntos y guion segun corresponda.
        private void txt_gotFocus(object sender, RoutedEventArgs e)
        {
            txtRut.Text = txtRut.Text.Replace("-", "");
            txtRut.Text = txtRut.Text.Replace(".", "");
        }
        //Metodo ejecutado al perder el foco del campo rut. Resetea el rut , y le agrega punto y guion segun corresponda.
        private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        {

            parseaLogin(txtRut.Text);
        }
        private bool parseaLogin(string rut)
        {
            bool retorno = false;
            if (rut.Length == 8)
            {
                if (oUsr.MA_VALIDA_RUT(txtRut.Text))
                {
                    String linea = rut.Substring(0, 1);
                    String linea1 = rut.Substring(1, 3);
                    String linea2 = rut.Substring(4, 3);
                    String dv = rut.Substring(rut.Length - 1);
                    txtRut.Text = linea + '.' + linea1 + '.' + linea2 + '-' + dv;
                    retorno = true;
                }
                else
                {
                    MessageBox.Show("Rut Invalido",
                        "Alerta", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);

                    retorno = false;
                }
            }
            else if (rut.Length == 9)
            {
                if (oUsr.MA_VALIDA_RUT(txtRut.Text))
                {
                    String linea = rut.Substring(0, 2);
                    String linea1 = rut.Substring(2, 3);
                    String linea2 = rut.Substring(5, 3);
                    String dv = rut.Substring(rut.Length - 1);
                    txtRut.Text = linea + '.' + linea1 + '.' + linea2 + '-' + dv;
                    retorno = true;
                }
                else
                {
                    MessageBox.Show("Rut Invalido",
                        "Alerta", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                    limpiar();
                    retorno = false;
                }
            }
            return retorno;
        }
        //Metodo de validacion que revisa integridad de los campos en el formulario
        private String validar()
        {
            string mensaje = string.Empty;
            if (string.IsNullOrEmpty(txtRut.Text))
            {
                mensaje += "-Ingresar Rut Para asociación de Hora\n";
            }
            if (cmbEspecialidad.SelectedValue == null || cmbEspecialidad.SelectedValue == "0")
            {
                mensaje += "-Ingresar especialidad Para asociación de Hora\n";
            }
            if (cmbCentro.SelectedValue == null || cmbCentro.SelectedValue == "0")
            {
                mensaje += "-Ingresar centro Para asociación de Hora\n";
            }
            return mensaje;
        }
        //Metodo que limpia formulario
        private void limpiar()
        {
            foreach (object c in ContenidoPagina.Children)
            {
                if (c is TextBox)
                {
                    (c as TextBox).Text = String.Empty;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).SelectedValue = "0";
                }
            }
        }

        private void cmbEspecialidad_Loaded(object sender, RoutedEventArgs e)
        {


            DataTable datos = oUsr.MA_LIST_ESPECIALIDADES_SALUD();
            DataRow nuevaFila = datos.NewRow();
            nuevaFila["MA_D_ID"] = "0";
            nuevaFila["MA_D_DESCRIPCION"] = "SELECCIONE ESPECIALIDAD...";
            datos.Rows.Add(nuevaFila);

            cmbEspecialidad.ItemsSource = datos.DefaultView;
            cmbEspecialidad.DisplayMemberPath = "MA_D_DESCRIPCION";
            cmbEspecialidad.SelectedValuePath = "MA_D_ID";
            cmbEspecialidad.SelectedValue = "0";
        }

        private void cmbCentro_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cmbEspecialidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string newItem = ((DataRowView)e.AddedItems[0]).Row.ItemArray[0].ToString();
            DataTable datos = oUsr.MA_TRAE_DEPENDENCIAS(newItem);
            DataRow nuevaFila = datos.NewRow();
            nuevaFila["MA_D_ID"] = "0";
            nuevaFila["MA_D_DESCRIPCION"] = "SELECCIONE CENTRO...";
            datos.Rows.Add(nuevaFila);

            cmbCentro.ItemsSource = datos.DefaultView;
            cmbCentro.DisplayMemberPath = "MA_D_DESCRIPCION";
            cmbCentro.SelectedValuePath = "MA_D_ID";
            cmbCentro.SelectedValue = "0";
        }

        private void dtFecha_Loaded(object sender, RoutedEventArgs e)
        {
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            dtFecha.BlackoutDates.Add(cdr);
        }

        private void timePicker_Loaded(object sender, RoutedEventArgs e)
        {
            int time = DateTime.Now.Minute;
            if (time.IsBetween(0, 15)) { time = 15; }
            else if (time.IsBetween(16, 30)) { time = 30; }
            else if (time.IsBetween(31, 45)) { time = 45; }
            else if (time.IsBetween(46, 60)) { time = 60; }

            timePicker.StartTime = new TimeSpan(DateTime.Now.Hour + 1, time, 00);
        }
    }
}
