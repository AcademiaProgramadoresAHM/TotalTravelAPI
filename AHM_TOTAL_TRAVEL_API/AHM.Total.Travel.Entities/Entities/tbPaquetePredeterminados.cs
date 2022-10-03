﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class tbPaquetePredeterminados
    {
        public tbPaquetePredeterminados()
        {
            tbPaquetePredeterminadosDetalles = new HashSet<tbPaquetePredeterminadosDetalles>();
            tbPaquetesHabitaciones = new HashSet<tbPaquetesHabitaciones>();
            tbReservaciones = new HashSet<tbReservaciones>();
        }

        public int Paqu_ID { get; set; }
        public string Paqu_Nombre { get; set; }
        public string Paqu_Descripcion { get; set; }
        public string Paqu_Duracion { get; set; }
        public int? Hote_ID { get; set; }
        public int? Rest_ID { get; set; }
        public int? Paqu_UsuarioCreacion { get; set; }
        public DateTime? Paqu_FechaCreacion { get; set; }
        public int? Paqu_UsuarioModifica { get; set; }
        public DateTime? Paqu_FechaModifica { get; set; }
        public bool? Paqu_Estado { get; set; }
        public decimal? Paqu_Precio { get; set; }

        public virtual tbHoteles Hote { get; set; }
        public virtual tbUsuarios Paqu_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Paqu_UsuarioModificaNavigation { get; set; }
        public virtual tbRestaurantes Rest { get; set; }
        public virtual ICollection<tbPaquetePredeterminadosDetalles> tbPaquetePredeterminadosDetalles { get; set; }
        public virtual ICollection<tbPaquetesHabitaciones> tbPaquetesHabitaciones { get; set; }
        public virtual ICollection<tbReservaciones> tbReservaciones { get; set; }
    }
}