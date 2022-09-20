﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class tbActividades
    {
        public tbActividades()
        {
            tbActividadesExtras = new HashSet<tbActividadesExtras>();
            tbHotelesActividades = new HashSet<tbHotelesActividades>();
            tbPaquetePredeterminadosDetalles = new HashSet<tbPaquetePredeterminadosDetalles>();
        }

        public int Actv_ID { get; set; }
        public string Actv_Descripcion { get; set; }
        public int? TiAc_ID { get; set; }
        public int? Actv_UsuarioCreacion { get; set; }
        public DateTime? Actv_FechaCreacion { get; set; }
        public int? Actv_UsuarioModifica { get; set; }
        public DateTime? Actv_FechaModifica { get; set; }
        public bool? Actv_Estado { get; set; }

        public virtual tbUsuarios Actv_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Actv_UsuarioModificaNavigation { get; set; }
        public virtual tbTiposActividades TiAc { get; set; }
        public virtual ICollection<tbActividadesExtras> tbActividadesExtras { get; set; }
        public virtual ICollection<tbHotelesActividades> tbHotelesActividades { get; set; }
        public virtual ICollection<tbPaquetePredeterminadosDetalles> tbPaquetePredeterminadosDetalles { get; set; }
    }
}