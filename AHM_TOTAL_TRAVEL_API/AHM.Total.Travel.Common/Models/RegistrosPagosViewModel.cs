using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class RegistrosPagosViewModel
    {
        public int? Resv_ID { get; set; }
        public int? TiPa_ID { get; set; }
        public decimal? RePa_Monto { get; set; }
        public DateTime? RePa_FechaPago { get; set; }
        public int? RePa_UsuarioCreacion { get; set; }
        public int? RePa_UsuarioModifica { get; set; }
    }
}
