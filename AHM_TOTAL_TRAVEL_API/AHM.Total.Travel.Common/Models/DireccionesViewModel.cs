using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class DireccionesViewModel
    {
        public int Dire_ID { get; set; }
        public string Dire_Descripcion { get; set; }
        public int? Ciud_ID { get; set; }
        public int? Dire_UsuarioCreacion { get; set; }
        public DateTime? Dire_FechaCreacion { get; set; }
        public int? Dire_UsuarioModifica { get; set; }
        public DateTime? Dire_FechaModifica { get; set; }
        public bool? Dire_Estado { get; set; }
    }
}
