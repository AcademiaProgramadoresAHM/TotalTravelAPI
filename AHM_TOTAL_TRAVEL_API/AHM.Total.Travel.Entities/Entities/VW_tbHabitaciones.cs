﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class VW_tbHabitaciones
    {
        public int ID { get; set; }
        public string Habitacion { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaHabitacionID { get; set; }
        public string Categoria { get; set; }
        public int HotelID { get; set; }
        public string Hotel { get; set; }
        public int? PartnerID { get; set; }
        public decimal? Precio { get; set; }
        public int? Balcon { get; set; }
        public bool? Wifi { get; set; }
        public int? Camas { get; set; }
        public int? Capacidad { get; set; }
        public string ImageUrl { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public bool? Estado { get; set; }
    }
}