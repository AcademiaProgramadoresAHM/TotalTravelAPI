﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class tbActividadesExtras
    {
        public tbActividadesExtras()
        {
            tbReservacionesActividadesExtras = new HashSet<tbReservacionesActividadesExtras>();
        }

        public int AcEx_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Actv_ID { get; set; }
        public decimal? AcEx_Precio { get; set; }
        public string AcEx_Descripcion { get; set; }
        public int? AcEx_UsuarioCreacion { get; set; }
        public DateTime? AcEx_FechaCreacion { get; set; }
        public int? AcEx_UsuarioModifica { get; set; }
        public DateTime? AcEx_FechaModifica { get; set; }
        public bool? AcEx_Estado { get; set; }

        public virtual tbUsuarios AcEx_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios AcEx_UsuarioModificaNavigation { get; set; }
        public virtual tbActividades Actv_ { get; set; }
        public virtual tbPartners Part_ { get; set; }
        public virtual ICollection<tbReservacionesActividadesExtras> tbReservacionesActividadesExtras { get; set; }
    }
}