﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class VW_tbTransportesCompleto
    {
        public int ID { get; set; }
        public int? TipoTransporteID { get; set; }
        public string TipoTransporte { get; set; }
        public decimal? Precio { get; set; }
        public int HorarioID { get; set; }
        public string HoraSalida { get; set; }
        public string HoraLlegada { get; set; }
        public int? PartnerID { get; set; }
        public string NombrePartner { get; set; }
        public string image_URL { get; set; }
        public int Ciudad_ID { get; set; }
        public string Ciudad { get; set; }
        public int? DireccionId { get; set; }
        public int ColoniaId { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Avenida { get; set; }
        public int? UsuarioCreacionID { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? UsuarioModificaID { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public bool? Estado { get; set; }
    }
}