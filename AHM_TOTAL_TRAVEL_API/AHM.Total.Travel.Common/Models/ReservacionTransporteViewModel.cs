using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionTransporteViewModel
    {
        public int Id { get; set; }
        public int? Capacidad { get; set; }
        public decimal? Precio { get; set; }
        public int? Reservacion { get; set; }
        public int? Asientos { get; set; }
        public bool? Cancelado { get; set; }
        public DateTime? Fecha_Cancelado { get; set; }
        public int? Usuario_Creacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public int? Usuario_Modifica { get; set; }
        public DateTime? Fecha_Modifica { get; set; }
        public bool? Estado { get; set; }
    }
}
