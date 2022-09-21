using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionesDetallesViewModel
    {
        public int ID { get; set; }
        public string Nombre_Habitacion { get; set; }
        public string Descripcion_Habitacion { get; set; }
        public string Categoria_Habitacion { get; set; }
        public string Hotel { get; set; }
        public string Precio_Habitacion { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public int Precio_ReservacionHotel { get; set; }
        public int? Usuario_Creacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public int? Usuario_Modifica { get; set; }
        public DateTime? Fecha_Modifica { get; set; }
        public bool? Estado { get; set; }
    }
}
