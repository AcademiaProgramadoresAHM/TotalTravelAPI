﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class VW_tbHorariosTransportes
    {
        public int ID { get; set; }
        public int ID_Destino { get; set; }
        public int Ciudad_Salida_ID { get; set; }
        public string Ciudad_Salida { get; set; }
        public int Ciudad_Destino_ID { get; set; }
        public string Ciudad_Destino { get; set; }
        public int Horario_ID { get; set; }
        public DateTime? Fecha { get; set; }
        public string Hora_Salida { get; set; }
        public string Hora_Llegada { get; set; }
        public int Partner_ID { get; set; }
        public string Partner_Nombre { get; set; }
        public int Usuario_Creacion_ID { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public int? Usuario_Modifica_ID { get; set; }
        public string Usuario_Modifica { get; set; }
        public DateTime? Fecha_Modifica { get; set; }
        public bool? Estado { get; set; }
    }
}