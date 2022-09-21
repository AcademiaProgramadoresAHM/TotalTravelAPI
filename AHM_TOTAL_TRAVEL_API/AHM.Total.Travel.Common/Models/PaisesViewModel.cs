using System;

namespace AHM.Total.Travel.Common.Models
{
    public class PaisesViewModel
    {
        public int Pais_ID { get; set; }
        public string Pais_Codigo { get; set; }
        public string Pais_Descripcion { get; set; }
        public string Pais_Nacionalidad { get; set; }
        public int? Pais_UsuarioCreacion { get; set; }
        public DateTime? Pais_FechaCreacion { get; set; }
        public int? Pais_UsuarioModifica { get; set; }
        public DateTime? Pais_FechaModifica { get; set; }
        public bool? Pais_Estado { get; set; }
    }
}
