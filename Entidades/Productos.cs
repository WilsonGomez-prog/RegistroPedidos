using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroPedidos.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public float Costo { get; set; }
        public int Inventario { get; set; }

        public Productos()
        {
            ProductoId = 0;
            Descripcion = "";
            Costo = 0.0f;
            Inventario = 0;
        }

        public Productos(int id, string descripcionProd, float precio, int existencia)
        {
            ProductoId = id;
            Descripcion = descripcionProd;
            Costo = precio;
            Inventario = existencia;
        }
    }
}