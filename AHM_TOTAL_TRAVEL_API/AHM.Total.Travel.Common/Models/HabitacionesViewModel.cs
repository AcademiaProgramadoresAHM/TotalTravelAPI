using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class HabitacionesViewModel
    {
        public string Habi_Nombre { get; set; }
        public string Habi_Descripcion { get; set; }
        public int? CaHa_ID { get; set; }
        public int? Hote_ID { get; set; }
        public decimal? Habi_Precio { get; set; }
        public int? Habi_capacidad { get; set; }
        public int? Habi_camas { get; set; }
        public byte? Habi_wifi { get; set; }
        public int? Habi_balcon { get; set; }
        public string Habi_url { get; set; }
        public int? Habi_UsuarioCreacion { get; set; }
        public int? Habi_UsuarioModifica { get; set; }
        public List<IFormFile> File { get; set; }


    }
}
