using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
   public  class RolesPermisosViewModel
    {
        public int RoPe_ID { get; set; }
        public string Perm_ID { get; set; }
        public string Role_ID { get; set; }
        public string RoPe_UsuarioCreacion { get; set; }
        public DateTime? RoPe_FechaCreacion { get; set; }
        public string RoPe_UsuarioModifica { get; set; }
        public DateTime? RoPe_FechaModifica { get; set; }
        public bool? RoPe_Estado { get; set; }
    }
}
