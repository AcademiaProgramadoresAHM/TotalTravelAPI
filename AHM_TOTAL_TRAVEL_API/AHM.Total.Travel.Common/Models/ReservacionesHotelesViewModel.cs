using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionesHotelesViewModel
    {
        public DateTime? ReHo_FechaEntrada { get; set; }
        public DateTime? ReHo_FechaSalida { get; set; }
        public int? Resv_ID { get; set; }
        public int? Hote_ID { get; set; }
        public decimal? ReHo_PrecioTotal { get; set; }
        public int? ReHo_UsuarioCreacion { get; set; }
        public int? ReHo_UsuarioModifica { get; set; }
    }
}
