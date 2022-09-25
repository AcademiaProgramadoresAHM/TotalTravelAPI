using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionesHotelesViewModel
    {
        public int ReHo_ID { get; set; }
        public DateTime? ReHo_FechaEntrada { get; set; }
        public DateTime? ReHo_FechaSalida { get; set; }
        public int? Resv_ID { get; set; }
        public decimal? ReHo_PrecioTotal { get; set; }
        public int? ReHo_UsuarioCreacion { get; set; }
        public DateTime? ReHo_FechaCreacion { get; set; }
        public int? ReHo_UsuarioModifica { get; set; }
        public DateTime? ReHo_FechaModifica { get; set; }
        public bool? ReHo_Estado { get; set; }
    }
}
