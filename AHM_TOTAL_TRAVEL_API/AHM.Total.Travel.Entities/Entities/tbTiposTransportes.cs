﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class tbTiposTransportes
    {
        public tbTiposTransportes()
        {
            tbTransportes = new HashSet<tbTransportes>();
        }

        public int TiTr_ID { get; set; }
        public string TiTr_Descripcion { get; set; }
        public int? TiTr_UsuarioCreacion { get; set; }
        public DateTime? TiTr_FechaCreacion { get; set; }
        public int? TiTr_UsuarioModifica { get; set; }
        public DateTime? TiTr_FechaModifica { get; set; }
        public bool? TiTr_Estado { get; set; }
        public int? Partner_ID { get; set; }

        public virtual tbUsuarios TiTr_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios TiTr_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbTransportes> tbTransportes { get; set; }
    }
}