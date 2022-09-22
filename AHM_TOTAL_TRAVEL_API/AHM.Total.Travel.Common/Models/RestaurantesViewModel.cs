﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class RestaurantesViewModel
    {

        public int Rest_ID { get; set; }
        public int? Dire_ID { get; set; }
        public string Rest_Nombre { get; set; }
        public int? Part_ID { get; set; }
        public int? Rest_UsuarioCreacion { get; set; }
        public DateTime? Rest_FechaCreacion { get; set; }
        public int? Rest_UsuarioModifica { get; set; }
        public DateTime? Rest_FechaModifica { get; set; }
        public bool? Rest_Estado { get; set; }
    }
}
