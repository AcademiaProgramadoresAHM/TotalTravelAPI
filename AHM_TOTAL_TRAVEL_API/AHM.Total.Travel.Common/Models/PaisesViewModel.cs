using System;

namespace AHM.Total.Travel.Common.Models
{
    public class PaisesViewModel
    {
        public string Pais_Codigo { get; set; }
        public string Pais_ISO { get; set; }
        public string Pais_Descripcion { get; set; }
        public string Pais_Nacionalidad { get; set; }
        public int? Pais_UsuarioCreacion { get; set; }
        public int? Pais_UsuarioModifica { get; set; }
    }
}
