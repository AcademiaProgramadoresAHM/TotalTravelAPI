using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class HotelesViewModel
    {
        public string Hote_Nombre { get; set; }
        public string Hote_Descripcion { get; set; }
        public int? Dire_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Hote_UsuarioCreacion { get; set; }
        public int? Hote_UsuarioModifica { get; set; }
        public string Hote_Url { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
