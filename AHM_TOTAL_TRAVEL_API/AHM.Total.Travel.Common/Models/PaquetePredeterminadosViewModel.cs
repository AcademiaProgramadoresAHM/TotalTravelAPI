﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class PaquetePredeterminadosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion_Paquete { get; set; }
        public string Duracion_Paquete { get; set; }
        public string Hotel { get; set; }
        public string Descripcion_Hotel { get; set; }
        public string Restaurante { get; set; }
        public int? Usuario_Creacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public int? Usuario_Modifica { get; set; }
        public DateTime? Fecha_Modifcia { get; set; }
        public bool? Estado { get; set; }
    }
}
