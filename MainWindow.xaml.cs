using RegistroPedidos.UI.Consultas;
using RegistroPedidos.UI.Registro;
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

namespace RegistroPedidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rOrdenesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rOrdenes ventanaOrdenes = new rOrdenes();
            ventanaOrdenes.Show();
        }

        private void cOrdenesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cOrdenes consultaOrdenes = new cOrdenes();
            consultaOrdenes.Show();
        }

        private void cSuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cSuplidores consultaSuplidores = new cSuplidores();
            consultaSuplidores.Show();
        }

        private void cProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cProductos consultaProductos = new cProductos();
            consultaProductos.Show();
        }
    }
}
