using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class MenusViewModel
    {
        public int Menu_ID { get; set; }
        public int? Time_ID { get; set; }
        public string Menu_Descripcion { get; set; }
        public string Menu_Nombre { get; set; }
        public decimal? Menu_Precio { get; set; }
        public int? Rest_ID { get; set; }
        public int? Menu_UsuarioCreacion { get; set; }
        public DateTime? Menu_FechaCreacion { get; set; }
        public int? Menu_UsuarioModifica { get; set; }
        public DateTime? Menu_FechaModifica { get; set; }
        public bool? Menu_Estado { get; set; }
    }
}
