using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionesActividadesExtrasViewModel
    {

        public int ReAE_ID { get; set; }
        public int? Resv_ID { get; set; }
        public int? AcEx_ID { get; set; }
        public string ReAE_Precio { get; set; }
        public int? ReAE_Cantidad { get; set; }
        public DateTime? ReAE_FechaReservacion { get; set; }
        public string ReAE_HoraReservacion { get; set; }
        public int? ReAE_UsuarioCreacion { get; set; }
        public int? ReAE_UsuarioModifica { get; set; }
    }
}
