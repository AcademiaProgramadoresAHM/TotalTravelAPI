using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class TipoMenusViewModel
    {
        public int Time_ID { get; set; }
        public string Time_Descripcion { get; set; }
        public int? Time_UsuarioCreacion { get; set; }
        public DateTime? Time_FechaCreacion { get; set; }
        public int? Time_UsuarioModifica { get; set; }
        public DateTime? Time_FechaModifica { get; set; }
        public bool? Time_Estado { get; set; }
    }
}
