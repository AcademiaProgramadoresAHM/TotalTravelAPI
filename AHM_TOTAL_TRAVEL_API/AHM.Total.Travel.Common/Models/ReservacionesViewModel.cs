﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionesViewModel
    {
        public int Resv_ID { get; set; }
        public int? Usua_ID { get; set; }
        public int? Paqu_ID { get; set; }
        public bool? Resv_esPersonalizado { get; set; }
        public int? Resv_NumeroPersonas { get; set; }
        public bool? Resv_ConfirmacionPago { get; set; }
        public bool? Resv_ConfirmacionHotel { get; set; }
        public bool? Resv_ConfirmacionRestaurante { get; set; }
        public bool? Resv_ConfirmacionTrans { get; set; }
        public decimal? Resv_Precio { get; set; }
        public int? Resv_UsuarioCreacion { get; set; }
        public DateTime? Resv_FechaCreacion { get; set; }
        public int? Resv_UsuarioModifica { get; set; }
        public DateTime? Resv_FechaModifica { get; set; }
        public bool? Resv_Estado { get; set; }
    }
}
