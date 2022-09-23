using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class TiposActividadesViewModel
    {
        public int TiAc_ID { get; set; }
        public string TiAc_Descripcion { get; set; }
        public int? TiAc_UsuarioCreacion { get; set; }
        public DateTime? TiAc_FechaCreacion { get; set; }
        public int? TiAc_UsuarioModifica { get; set; }
        public DateTime? TiAc_FechaModifica { get; set; }
        public bool? TiAc_Estado { get; set; }
    }
}
