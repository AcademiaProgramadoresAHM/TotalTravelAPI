using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
   public class TiposTransportesViewModel
    {
        public int TiTr_ID { get; set; }
        public string TiTr_Descripcion { get; set; }
        public int? TiTr_UsuarioCreacion { get; set; }
        public DateTime? TiTr_FechaCreacion { get; set; }
        public int? TiTr_UsuarioModifica { get; set; }
        public DateTime? TiTr_FechaModifica { get; set; }
        public bool? TiTr_Estado { get; set; }
    }
}
