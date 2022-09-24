using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ActividadesViewModel
    {
        public int Actv_ID { get; set; }
        public string Actv_Descripcion { get; set; }
        public int? TiAc_ID { get; set; }
        public int? Actv_UsuarioCreacion { get; set; }
        public DateTime? Actv_FechaCreacion { get; set; }
        public int? Actv_UsuarioModifica { get; set; }
        public DateTime? Actv_FechaModifica { get; set; }
        public bool? Actv_Estado { get; set; }
    }
}
