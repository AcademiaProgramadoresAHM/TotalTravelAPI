﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class VW_tbDetallesTransportes
    {
        public int ID { get; set; }
        public int Tipo_Transporte_ID { get; set; }
        public string Tipo_Transporte { get; set; }
        public int? Partner_ID { get; set; }
        public string Parter { get; set; }
        public string image_URL { get; set; }
        public int Horario_ID { get; set; }
        public DateTime? Fecha_Salida { get; set; }
        public int DestinoDetalle_ID { get; set; }
        public int Ciudad_Salida_ID { get; set; }
        public string Ciudad_Salida { get; set; }
        public int Ciudad_Llegada_ID { get; set; }
        public string Ciudad_Llegada { get; set; }
        public string Hora_Salida { get; set; }
        public string Hora_Llegada { get; set; }
        public int? Capacidad { get; set; }
        public decimal? Precio { get; set; }
        public string Matricula { get; set; }
        public int Usuario_Creacion_ID { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public int? Usuario_Modifica_ID { get; set; }
        public string Usuario_Modifica { get; set; }
        public DateTime? Fecha_Modifica { get; set; }
        public bool? Estado { get; set; }
    }
}