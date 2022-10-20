using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ActividadesExtrasViewModel
    {
        public int? Part_ID { get; set; }
        public int? Actv_ID { get; set; }
        public int? Dire_ID { get; set; }
        public decimal? AcEx_Precio { get; set; }
        public string AcEx_Descripcion { get; set; }
        public int? Dire_ID { get; set; }
        public int? AcEx_UsuarioCreacion { get; set; }
        public int? AcEx_UsuarioModifica { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
