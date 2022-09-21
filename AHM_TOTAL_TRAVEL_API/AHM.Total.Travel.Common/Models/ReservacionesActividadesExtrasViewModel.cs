using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionesActividadesExtrasViewModel
    {
        public int ID { get; set; }
        public int? Reservacion_ID { get; set; }
        public string Cliente { get; set; }
        public string ActividadExtra { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? Fecha_Reservacion { get; set; }
        public string Hora_Reservacion { get; set; }
        public int? Usuario_Creacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public int? Usuario_Modifica { get; set; }
        public DateTime? Fecha_Modifica { get; set; }
        public bool? Estado { get; set; }
    }
}
