using AHM.Total.Travel.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionesViewModel
    {
        public int? Resv_ID { get; set; } = 0;
        public int? Usua_ID { get; set; }
        public int? Paqu_ID { get; set; }
        public bool Resv_esPersonalizado { get; set; }
        public int? Resv_CantidadPagos { get; set; }
        public int? Resv_NumeroPersonas { get; set; }
        [DefaultValue (false)]
        public bool? Resv_ConfirmacionPago { get; set; }
        [DefaultValue(false)]
        public bool? Resv_ConfirmacionHotel { get; set; }
        [DefaultValue(false)]
        public bool? Resv_ConfirmacionRestaurante { get; set; }
        [DefaultValue(false)]
        public bool? Resv_ConfirmacionTrans { get; set; }
        public decimal? Resv_Precio { get; set; }
        public int? Resv_UsuarioCreacion { get; set; }
        public int? Resv_UsuarioModifica { get; set; }

        //Need this data in order to make a reservation in HotelReservation
        
        public DateTime? ReHo_FechaEntrada { get; set; }
        public DateTime? ReHo_FechaSalida { get; set; }

        //Need this in order to make a reservation of a custom package
        public int? Hote_ID { get; set; }
        public List<ReservacionesActividadesExtrasViewModel> ActividadesExtras { get; set; } = null;
        public List<ReservacionRestaurantesViewModel> Restaurantes { get; set; } = null;
        public List<ReservacionesActividadesHotelesViewModel> ActividadesHoteles { get; set; } = null; 
        public int? TipoPago { get; set; }
        public int? Habi_ID { get; set; }
        public int? Habi_Cantidad { get; set;  }

        //Need this to make the reservation of a transport
        public List<ReservacionTransporteViewModel> reservacionTransportes { get; set; }
        public ReservacionesViewModel()
        {
            Resv_ConfirmacionPago = false;
            Resv_ConfirmacionHotel = false;
            Resv_ConfirmacionRestaurante = false;
            Resv_ConfirmacionTrans = false;
        }
    }
}
