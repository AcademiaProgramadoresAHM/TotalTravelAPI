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
        [DefaultValue(false)]
        public bool? Resv_ConfirmacionPago { get; set; }
        [DefaultValue(false)]
        public bool? Resv_ConfirmacionHotel { get; set; }
        [DefaultValue(false)]
        public bool? Resv_ConfirmacionRestaurante { get; set; }
        [DefaultValue(false)]
        public bool? Resv_ConfirmacionTrans { get; set; }
        public bool? Resv_ConfirmacionActividades { get; set; }

        public bool JustConfirmation { get; set; }
        public decimal? Resv_Precio { get; set; }
        public int? Resv_UsuarioCreacion { get; set; }
        public int? Resv_UsuarioModifica { get; set; }

        //Need this data in order to make a reservation in HotelReservation

        public DateTime? ReHo_FechaEntrada { get; set; }
        public DateTime? ReHo_FechaSalida { get; set; }

        //Need this in order to make a reservation of a custom package
        public int? Hote_ID { get; set; }
        public List<ReservacionesActividadesExtras> ActividadesExtras { get; set; } = null;
        public List<ReservacionRestaurantes> Restaurantes { get; set; } = null;
        public List<ReservacionesActividadesHoteles> ActividadesHoteles { get; set; } = null;
        public List<ReservacionHabitaciones> Resv_Habitaciones { get; set; } = null;
        public int? TipoPago { get; set; }
        public int? Habi_ID { get; set; }
        public int? Habi_Cantidad { get; set; }

        //Need this to make the reservation of a transport
        public List<ReservacionTransporte> reservacionTransportes { get; set; }
        public ReservacionesViewModel()
        {
            Resv_ConfirmacionPago = false;
            Resv_ConfirmacionHotel = false;
            Resv_ConfirmacionRestaurante = false;
            Resv_ConfirmacionTrans = false;
        }


        public class ReservacionesActividadesExtras
        {
            public int ReAE_ID { get; set; }
            public int? AcEx_ID { get; set; }
            public decimal ReAE_Precio { get; set; }
            public int? ReAE_Cantidad { get; set; }
            public DateTime? ReAE_FechaReservacion { get; set; }
            public string ReAE_HoraReservacion { get; set; }
        }
        public class ReservacionRestaurantes
        {
            public int ReRe_ID { get; set; }
            public int? Resv_ID { get; set; }
            public int? Rest_ID { get; set; }
            public DateTime? ReRe_FechaReservacion { get; set; }
            public string ReRe_HoraReservacion { get; set; }
        }
        public class ReservacionesActividadesHoteles
        {
            public int ReAH_ID { get; set; }
            public int? HoAc_ID { get; set; }
            public decimal? ReAH_Precio { get; set; }
            public int? ReAH_Cantidad { get; set; }
            public DateTime? ReAH_FechaReservacion { get; set; }
            public string ReAH_HoraReservacion { get; set; }
        }
        public class ReservacionTransporte
        {
            public int ReTr_ID { get; set; }
            public int? Detr_ID { get; set; }
            public int? ReTr_CantidadAsientos { get; set; }
            public bool? ReTr_Cancelado { get; set; }
            public DateTime? ReTr_FechaCancelado { get; set; }

            public ReservacionTransporte()
            {
                ReTr_Cancelado = false;
            }
        }
        public class ReservacionHabitaciones
        {
            public int ReDe_ID { get; set; }
            public int Habi_ID { get; set; }
            public int Habi_Cantidad { get; set; }
        }
    }

    public class ReservacionesDetalleViewModel
    {
        public VW_tbReservaciones reservacionDetalle { get; set; } = null;
        public List<ReservacionesActividadesExtrasDetail> ActividadesExtras { get; set; } = null;
        public List<ReservacionRestaurantesDetail> Restaurantes { get; set; } = null;
        public List<ReservacionesActividadesHotelesDetail> ActividadesHoteles { get; set; } = null;
        public List<ReservacionHabitacionesDetail> Habitaciones { get; set; } = null;
        public List<ReservacionTransporteDetail> Transportes { get; set; }

        public class ReservacionesActividadesExtrasDetail
        {
            public VW_tbActividadesExtras details { get; set; }
            public int? AcEx_ID { get; set; }
            public decimal ReAE_Precio { get; set; }
            public int? ReAE_Cantidad { get; set; }
            public DateTime? ReAE_FechaReservacion { get; set; }
            public string ReAE_HoraReservacion { get; set; }
        }
        public class ReservacionRestaurantesDetail
        {
            public VW_tbRestaurantes details { get; set; }
            public int? Rest_ID { get; set; }
            public DateTime? ReRe_FechaReservacion { get; set; }
            public string ReRe_HoraReservacion { get; set; }
        }
        public class ReservacionesActividadesHotelesDetail
        {
            public VW_tbHotelesActividades details { get; set; }
            public int? HoAc_ID { get; set; }
            public decimal? ReAH_Precio { get; set; }
            public int? ReAH_Cantidad { get; set; }
            public DateTime? ReAH_FechaReservacion { get; set; }
            public string ReAH_HoraReservacion { get; set; }
        }
        public class ReservacionTransporteDetail
        {
            public VW_tbDetallesTransportes details { get; set; }
            public int? Detr_ID { get; set; }
            public int? ReTr_CantidadAsientos { get; set; }
            public DateTime? ReTr_FechaCancelado { get; set; }
        }
        public class ReservacionHabitacionesDetail
        {
            public VW_tbHabitaciones details { get; set; }
            public int Habi_ID { get; set; }
            public int Habi_Cantidad { get; set; }
        }
    }

}
