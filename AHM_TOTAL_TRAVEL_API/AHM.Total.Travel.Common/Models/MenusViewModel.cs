﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class MenusViewModel
    {
        public int? Time_ID { get; set; }
        public string Menu_Descripcion { get; set; }
        public string Menu_Nombre { get; set; }
        public decimal? Menu_Precio { get; set; }
        public int? Rest_ID { get; set; }
        public int? Menu_UsuarioCreacion { get; set; }
        public int? Menu_UsuarioModifica { get; set; }
        public List<IFormFile> File { get; set; }
    }

    public class MenusListViewModel
    {
        public int ID { get; set; }
        public string Restaurante { get; set; }
        public string TipoMenu { get; set; }
        public string Menu { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public bool? Estado { get; set; }
    }
}
