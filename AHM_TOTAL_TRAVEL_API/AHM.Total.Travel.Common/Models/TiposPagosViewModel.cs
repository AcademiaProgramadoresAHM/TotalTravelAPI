using AHM.Total.Travel.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class TiposPagosViewModel
    {
        public int TiPa_ID { get; set; }
        public string TiPa_Descripcion { get; set; }
        public int? TiPa_UsuarioCreacion { get; set; }
        public DateTime? TiPa_FechaCreacion { get; set; }
        public int? TiPa_UsuarioModifica { get; set; }
        public DateTime? TiPa_FechaModifica { get; set; }
        public bool? TiPa_Estado { get; set; }

    }
}
