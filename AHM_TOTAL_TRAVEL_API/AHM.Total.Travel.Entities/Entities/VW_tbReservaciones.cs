﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class VW_tbReservaciones
    {
        public int ID { get; set; }
        public int? NumeroPersonas { get; set; }
        public int? CantidadPagos { get; set; }
        public int? Id_Paquete { get; set; }
        public string DescripcionPaquete { get; set; }
        public decimal? precio { get; set; }
        public DateTime? Fecha_Entrada { get; set; }
        public DateTime? Fecha_Salida { get; set; }
        public int Hotel_ID { get; set; }
        public string Nombre_Hotel { get; set; }
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool? ConfirmacionHotel { get; set; }
        public bool? ConfirmacionRestaurante { get; set; }
        public bool? ConfirmacionTransporte { get; set; }
        public bool? ConfirmacionPago { get; set; }
        public int? Id_UsuarioCrea { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Id_UsuarioModifica { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
    }
}