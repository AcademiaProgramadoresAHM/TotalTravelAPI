using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class RolesViewModel
    {
        public int Role_ID { get; set; }
        public string Role_Descripcion { get; set; }
        public int? Role_UsuarioCreacion { get; set; }
        public DateTime? Role_FechaCreacion { get; set; }
        public int? Role_UsuarioModifica { get; set; }
        public DateTime? Role_FechaModifica { get; set; }
        public bool? Role_Estado { get; set; }

    }
}
