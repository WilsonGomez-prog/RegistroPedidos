using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPedidos.Entidades
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public int SuplidorId { get; set; }
        public float Monto { get; set; }

        [ForeignKey("OrdenId")]
        public List<OrdenesDetalle> DetalleOrden { get; set; }

        public Ordenes()
        {
            OrdenId = 0;
            Fecha = DateTime.Now;
            SuplidorId = 0;
            Monto = 0.0f;
            DetalleOrden = new List<OrdenesDetalle>();
        }
    }
}