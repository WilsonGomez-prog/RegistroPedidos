using RegistroPedidos.BLL;
using RegistroPedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroPedidos.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para cSuplidores.xaml
    /// </summary>
    public partial class cSuplidores : Window
    {
        public cSuplidores()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Suplidores>();
            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                listado = SuplidoresBLL.GetSuplidores();
            }
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = SuplidoresBLL.GetList(e => e.SuplidorId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                    case 1:
                        listado = SuplidoresBLL.GetList(e => e.Nombre.Contains(CriterioTextBox.Text));
                        break;
                }
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

        }
    }
}
