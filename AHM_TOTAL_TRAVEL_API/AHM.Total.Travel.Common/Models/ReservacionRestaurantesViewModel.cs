using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionRestaurantesViewModel
    {

        public int ReRe_ID { get; set; }
        public int? Resv_ID { get; set; }
        public int? Rest_ID { get; set; }
        public DateTime? ReRe_FechaReservacion { get; set; }
        public string ReRe_HoraReservacion { get; set; }
        public int? ReRe_UsuarioCreacion { get; set; }
        public int? ReRe_UsuarioModifica { get; set; }

    }
}
