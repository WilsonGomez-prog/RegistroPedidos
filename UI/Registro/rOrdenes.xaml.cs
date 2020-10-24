using RegistroPedidos.BLL;
using RegistroPedidos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroPedidos.UI.Registro
{
    /// <summary>
    /// Lógica de interacción para rOrdenes.xaml
    /// </summary>
    public partial class rOrdenes : Window
    {
        Ordenes orden;
        public rOrdenes()
        {
            InitializeComponent();
            orden = new Ordenes();
            this.DataContext = orden;

            DetallesDataGrid.ItemsSource = new List<OrdenesDetalle>();

            SuplidorIdComboBox.ItemsSource = SuplidoresBLL.GetSuplidores();
            SuplidorIdComboBox.SelectedValuePath = "SuplidorId";
            SuplidorIdComboBox.DisplayMemberPath = "Nombre";

            ProductoIdComboBox.ItemsSource = ProductosBLL.GetProductos();
            ProductoIdComboBox.SelectedValuePath = "ProductosId";
            ProductoIdComboBox.DisplayMemberPath = "Descripcion";
        }

        public bool Existe()
        {
            var orden = OrdenesBLL.Buscar(Convert.ToInt32(OrdenIdTextBox.Text));

            return orden != null;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = orden;
            SuplidorIdComboBox.SelectedValue = (orden.SuplidorId - 1);
            FechaDatePicker.SelectedDate = orden.Fecha.Date;
            this.orden.DetalleOrden.Where(a => true).Select(a => new { Descripcion = $"{ProductosBLL.Buscar(a.ProductoId).Descripcion}"});
            DetallesDataGrid.ItemsSource = orden.DetalleOrden;
        }

        private void Limpiar()
        {
            this.orden = new Ordenes();
            this.DataContext = this.orden;

            DetallesDataGrid.ItemsSource = new List<OrdenesDetalle>();
            Actualizar();
        }

        private bool Validar()
        {
            bool valido = true;

            if (CantidadTextBox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Error, cantidad no válida, esta vacía.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (SuplidorIdComboBox.SelectedIndex < 0)
            {
                valido = false;
                MessageBox.Show("Error, suplidor no válido, \nno ha seleccionado ningún suplidor.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


            return valido;
        }

        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool guardado = false;

            orden.Fecha = Convert.ToDateTime(FechaDatePicker.SelectedDate.ToString());
            orden.SuplidorId = Convert.ToInt32(SuplidorIdComboBox.SelectedValue) + 1;

            if (string.IsNullOrWhiteSpace(OrdenIdTextBox.Text) || OrdenIdTextBox.Text == "0")
                guardado = OrdenesBLL.Guardar(orden);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("Esta orden no se puede modificar \nporque no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                guardado = OrdenesBLL.Modificar(orden);
            }

            if (guardado)
            {
                Limpiar();
                MessageBox.Show("La orden ha sido guardada correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Esta orden no ha podido ser guardada.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ordenes anterior = OrdenesBLL.Buscar(Convert.ToInt32(OrdenIdTextBox.Text));

            if (anterior != null)
            {
                orden = anterior;
                Actualizar();
                MessageBox.Show("Orden encontrada!!!!!");
            }
            else
            {
                MessageBox.Show("La orden buscada no ha podido ser encontrada.");
            }
        }

        public void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdenesBLL.Eliminar(Convert.ToInt32(OrdenIdTextBox.Text)))
            {
                MessageBox.Show("La orden ha sido eliminada correctamente.", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Esta orden no ha podido ser eliminada.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {     
            this.orden.DetalleOrden.Add(new OrdenesDetalle(orden.OrdenId, Convert.ToInt32(ProductoIdComboBox.SelectedValue) + 1, Convert.ToInt32(CantidadTextBox.Text), Convert.ToInt32(SuplidorIdComboBox.SelectedValue) + 1, ProductosBLL.Buscar(Convert.ToInt32(ProductoIdComboBox.SelectedValue) + 1).Costo * Convert.ToInt32(CantidadTextBox.Text)));
            this.orden.DetalleOrden.Where(a => true).Select(a => new { Descripcion = $"{ProductosBLL.Buscar(a.ProductoId).Descripcion}" });
            orden.Monto = 0;
            foreach(OrdenesDetalle detalle in orden.DetalleOrden)
            {
                orden.Monto += detalle.Costo;
            }
            Actualizar();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            orden.DetalleOrden.RemoveAt(DetallesDataGrid.FrozenColumnCount);
            orden.Monto = 0;
            foreach (OrdenesDetalle detalle in orden.DetalleOrden)
            {
                orden.Monto += detalle.Costo;
            }
            Actualizar();
        }
    }
}
