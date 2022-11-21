using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
   public  class RolesPermisosViewModel
    {
        public int Perm_ID { get; set; }
        public int Role_ID { get; set; }
        public int? RoPe_UsuarioCreacion { get; set; }
        public int? RoPe_UsuarioModifica { get; set; }
    }
}
