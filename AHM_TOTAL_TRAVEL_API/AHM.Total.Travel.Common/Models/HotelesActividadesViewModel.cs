using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class HotelesActividadesViewModel
    {
        public int? Actv_ID { get; set; }
        public string HoAc_Descripcion { get; set; }
        public decimal? HoAc_Precio { get; set; }
        public int? Hote_ID { get; set; }
        public string HoAc_Url { get; set; }
        public int? HoAc_UsuarioCreacion { get; set; }
        public int? HoAc_UsuarioModifica { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
