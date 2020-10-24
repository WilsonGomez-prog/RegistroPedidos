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
    /// Lógica de interacción para cOrdenes.xaml
    /// </summary>
    public partial class cOrdenes : Window
    {
        public cOrdenes()
        {
            InitializeComponent();
            DesdeDataPicker.SelectedDate = Convert.ToDateTime("1/01/0001");
            HastaDataPicker.SelectedDate = DateTime.Now;
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ordenes>();
            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                listado = OrdenesBLL.GetList(e => true);
            }
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = OrdenesBLL.GetList(e => e.OrdenId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                    case 1:
                        listado = OrdenesBLL.GetList(e => e.SuplidorId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                }
            }

            listado = OrdenesBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate && c.Fecha.Date <= HastaDataPicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

        }
    }
}
