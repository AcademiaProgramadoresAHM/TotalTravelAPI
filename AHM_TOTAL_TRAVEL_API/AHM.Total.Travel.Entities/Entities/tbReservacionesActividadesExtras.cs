﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class tbReservacionesActividadesExtras
    {
        public int ReAE_ID { get; set; }
        public int? Resv_ID { get; set; }
        public int? AcEx_ID { get; set; }
        public decimal? ReAE_Precio { get; set; }
        public int? ReAE_Cantidad { get; set; }
        public DateTime? ReAE_FechaReservacion { get; set; }
        public string ReAE_HoraReservacion { get; set; }
        public int? ReAE_UsuarioCreacion { get; set; }
        public DateTime? ReAE_FechaCreacion { get; set; }
        public int? ReAE_UsuarioModifica { get; set; }
        public DateTime? ReAE_FechaModifica { get; set; }
        public bool? ReAE_Estado { get; set; }

        public virtual tbActividadesExtras AcEx_ { get; set; }
        public virtual tbUsuarios ReAE_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios ReAE_UsuarioModificaNavigation { get; set; }
        public virtual tbReservaciones Resv_ { get; set; }
    }
}