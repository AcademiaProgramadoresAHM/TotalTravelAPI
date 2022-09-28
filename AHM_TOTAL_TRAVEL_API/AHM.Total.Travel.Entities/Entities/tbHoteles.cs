﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class tbHoteles
    {
        public tbHoteles()
        {
            tbHabitaciones = new HashSet<tbHabitaciones>();
            tbHotelesActividades = new HashSet<tbHotelesActividades>();
            tbHotelesMenus = new HashSet<tbHotelesMenus>();
            tbPaquetePredeterminados = new HashSet<tbPaquetePredeterminados>();
        }

        public int Hote_ID { get; set; }
        public string Hote_Nombre { get; set; }
        public string Hote_Descripcion { get; set; }
        public int? Dire_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Hote_UsuarioCreacion { get; set; }
        public DateTime? Hote_FechaCreacion { get; set; }
        public int? Hote_UsuarioModifica { get; set; }
        public DateTime? Hote_FechaModifica { get; set; }
        public bool? Hote_Estado { get; set; }
        public string Hote_Url { get; set; }

        public virtual tbDirecciones Dire { get; set; }
        public virtual tbUsuarios Hote_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Hote_UsuarioModificaNavigation { get; set; }
        public virtual tbPartners Part { get; set; }
        public virtual ICollection<tbHabitaciones> tbHabitaciones { get; set; }
        public virtual ICollection<tbHotelesActividades> tbHotelesActividades { get; set; }
        public virtual ICollection<tbHotelesMenus> tbHotelesMenus { get; set; }
        public virtual ICollection<tbPaquetePredeterminados> tbPaquetePredeterminados { get; set; }
    }
}