using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class TiposPartnersViewModel
    {
        public int TiPar_Id { get; set; }
        public string TiPar_Descripcion { get; set; }
        public int? Rol_Id { get; set; }
        public int? TiPar_UsuarioCreacion { get; set; }
        public DateTime? TiPar_FechaCreacion { get; set; }
        public int? TiPar_UsuarioModifica { get; set; }
        public DateTime? TiPar_FechaModifica { get; set; }
        public bool? TiPar_Estado { get; set; }
    }
}
