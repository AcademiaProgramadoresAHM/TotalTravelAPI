using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class PaquetePredeterminadosViewModel
    {
        public int Paqu_ID { get; set; }
        public string Paqu_Nombre { get; set; }
        public string Paqu_Descripcion { get; set; }
        public string Paqu_Duracion { get; set; }
        public int? Hote_ID { get; set; }
        public int? Rest_ID { get; set; }
        public int? Paqu_UsuarioCreacion { get; set; }
        public DateTime? Paqu_FechaCreacion { get; set; }
        public int? Paqu_UsuarioModifica { get; set; }
        public DateTime? Paqu_FechaModifica { get; set; }
        public bool? Paqu_Estado { get; set; }
    }
}
