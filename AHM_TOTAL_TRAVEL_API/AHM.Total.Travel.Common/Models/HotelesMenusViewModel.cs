using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class HotelesMenusViewModel
    {
        public string HoMe_Descripcion { get; set; }
        public decimal? HoMe_Precio { get; set; }
        public int? Hote_ID { get; set; }
        public int? Time_ID { get; set; }
        public int? HoMe_UsuarioCreacion { get; set; }
        public int? HoMe_UsuarioModifica { get; set; }

        public IFormFile File { get; set; }
    }
}
