﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class VW_tbReservacionesActividadesExtras
    {
        public int ID { get; set; }
        public int Reservacion { get; set; }
        public string Cliente { get; set; }
        public int Id_Actividad_Extra { get; set; }
        public string Actividad_Extra { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? Fecha_Reservacion { get; set; }
        public string Hora_Reservacion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public string Usuario_Modifica { get; set; }
        public DateTime? Fecha_Modifica { get; set; }
        public bool? Estado { get; set; }
    }
}