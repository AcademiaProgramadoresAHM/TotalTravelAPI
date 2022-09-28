using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class HotelesViewModel
    {
        public int Hote_ID { get; set; }
        public string Hote_Nombre { get; set; }
        public string Hote_Descripcion { get; set; }
        public int? Dire_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Hote_UsuarioCreacion { get; set; }
        public DateTime? Hote_FechaCreacion { get; set; }
        public int? Hote_UsuarioModifica { get; set; }
        public DateTime? Hote_FechaModifica { get; set; }
        public bool? Hote_Estado { get; set; }
        public string Hote_Url { get; set; }
    }
}
