using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroPedidos.Entidades
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int SuplidorId { get; set; }
        public float Costo { get; set; }

        public OrdenesDetalle()
        {
            Id = 0;
            OrdenId = 0;
            ProductoId = 0;
            Cantidad = 0;
            SuplidorId = 0;
            Costo = 0.0f;
        }

        public OrdenesDetalle(int orden, int producto, int cantidadOrdenada, int suplidor, float precio)
        {
            OrdenId = orden;
            ProductoId = producto;
            Cantidad = cantidadOrdenada;
            SuplidorId = suplidor;
            Costo = precio;
        }
    }
}