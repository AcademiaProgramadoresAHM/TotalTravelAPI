using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionesActividadesHotelesViewModel
    {

        public int ReAH_ID { get; set; }
        public int? Resv_ID { get; set; }
        public int? HoAc_ID { get; set; }
        public decimal? ReAH_Precio { get; set; }
        public int? ReAH_Cantidad { get; set; }
        public DateTime? ReAH_FechaReservacion { get; set; }
        public string ReAH_HoraReservacion { get; set; }
        public int? ReAH_UsuarioCreacion { get; set; }
        public int? ReAH_UsuarioModifica { get; set; }
    }
}
