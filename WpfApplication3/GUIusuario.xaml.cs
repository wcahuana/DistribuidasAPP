using System;
using System.Windows.Controls;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System.ComponentModel;
using System.Windows;
using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using WpfApplication3.AREAS.CSANPABLO;


namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for 
    /// 
    /// View.xaml
    /// </summary>
    public partial class GUIusuario : UserControl, InterfazGUI
    {

        readonly IObjectContainer container;

        public GUIusuario()
        {

            InitializeComponent();

   
        }

        MSize _MinSize;
        public MSize MinSize
        {
            get { return _MinSize; }  // (MSize)base.GetValue(MinSizeProperty); }
            set
            {
                _MinSize = value; // base.SetValue(MinSizeProperty, value);
                OnPropertyChanged("MinSize");
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
        #region IMySampleView Members

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public interfaceModeloPresentacionGUI Model
        {
            get { return this.DataContext as interfaceModeloPresentacionGUI; }
            set { this.DataContext = value; }
        }

        #endregion

        #region IView Members

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public object Context { get; set; }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        public void Create()
        {
        }

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public void Destroy()
        {
        }

        #endregion

        private void MySampleViewInteractionWorksheet_Loaded(object sender, RoutedEventArgs e)
        {
            CargaItems();
        }

        //se realiza captura de variable de sesion capturada desde libreria genesys. Con esto sabremos que gad mostrar segun área  de proceso
        void CargaItems()
        {

            try
            {
                TabItem TB = new TabItem();
                TB.Header = "Proyecto Distribuidas";
                TB.Width = 200;
                TB.Height = 50;
                TB.Name = "tblpersonas";
                TB.Style = this.FindResource("style_1") as Style;

                TB.Content = new CSANPABLO_custom();
          
                TabControlAreas.Items.Add(TB);
                
                TabControlAreas.Items.Refresh();
       
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }


    }
}
