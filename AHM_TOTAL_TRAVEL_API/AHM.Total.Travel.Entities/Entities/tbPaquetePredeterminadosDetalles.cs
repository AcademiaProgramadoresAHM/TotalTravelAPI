﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class tbPaquetePredeterminadosDetalles
    {
        public int PaDe_ID { get; set; }
        public int? Paqu_ID { get; set; }
        public int? Actv_ID { get; set; }
        public int? PaDe_UsuarioCreacion { get; set; }
        public DateTime? PaDe_FechaCreacion { get; set; }
        public int? PaDe_UsuarioModifica { get; set; }
        public DateTime? PaDe_FechaModifica { get; set; }
        public bool? PaDe_Estado { get; set; }

        public virtual tbActividades Actv { get; set; }
        public virtual tbUsuarios PaDe_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios PaDe_UsuarioModificaNavigation { get; set; }
    }
}