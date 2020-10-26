
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPedidos.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public float Monto { get; set; }

        [ForeignKey("VentasId")]
        public List<VentasDetalle> DetalleVentas { get; set; }

        public Ventas(DateTime fecha, float monto)
        {
            Fecha = fecha;
            Monto = monto;

            DetalleVentas = new List<VentasDetalle>();
        }

        public Ventas()
        {
            VentaId = 0;
            Fecha = DateTime.Now;
            Monto = 0.0f;
        }
    }

    public class VentasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int VentaId { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        
         public VentasDetalle()
        {
            VentaId = 0;
            Descripcion = "";
            Precio = 0.0f;
        }

        public VentasDetalle(int venta, string servicio, float precio)
        {
            VentaId = venta;
            Descripcion = servicio;
            Precio = precio;
        }
    }
}