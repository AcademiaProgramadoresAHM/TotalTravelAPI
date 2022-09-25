using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionesDetallesViewModel
    {
        public int ReDe_ID { get; set; }
        public int? Habi_ID { get; set; }
        public int? ReHo_ID { get; set; }
        public int? ReDe_UsuarioCreacion { get; set; }
        public DateTime? ReDe_FechaCreacion { get; set; }
        public int? ReDe_UsuarioModifica { get; set; }
        public DateTime? ReDe_FechaModifica { get; set; }
        public bool? ReDe_Estado { get; set; }
    }
}
