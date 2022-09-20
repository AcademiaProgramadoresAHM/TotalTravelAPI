using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class CiudadesViewModel
    {
        public int Ciud_ID { get; set; }
        public string Ciud_Descripcion { get; set; }
        public int? Pais_ID { get; set; }
        public int? Ciud_UsuarioCreacion { get; set; }
        public DateTime? Ciud_FechaCreacion { get; set; }
        public int? Ciud_UsuarioModifica { get; set; }
        public DateTime? Ciud_FechaModifica { get; set; }
        public bool? Ciud_Estado { get; set; }
    }
}
