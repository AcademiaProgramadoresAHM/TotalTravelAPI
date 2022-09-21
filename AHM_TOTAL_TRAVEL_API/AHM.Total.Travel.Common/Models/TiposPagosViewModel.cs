using AHM.Total.Travel.Entities.Entities;
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Common.Models
{
    public class TiposPagosViewModel
    {
        public int TiPa_ID { get; set; }
        public string TiPa_Descripcion { get; set; }
        public int? TiPa_UsuarioCreacion { get; set; }
        public DateTime? TiPa_FechaCreacion { get; set; }
        public int? TiPa_UsuarioModifica { get; set; }
        public DateTime? TiPa_FechaModifica { get; set; }
        public bool? TiPa_Estado { get; set; }

        public virtual tbUsuarios TiPa_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios TiPa_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbRegistrosPagos> tbRegistrosPagos { get; set; }
    }
}
