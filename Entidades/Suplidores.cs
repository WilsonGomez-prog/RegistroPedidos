using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroPedidos.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }
        public string Nombre { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            Nombre = "";
        }

        public Suplidores(int id, string nombreSuplidor)
        {
            SuplidorId = id;
            Nombre = nombreSuplidor;
        }
    }
}