using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class PermisosViewModel
    {
        public int Perm_ID { get; set; }
        public string Perm_Icono { get; set; }
        public string Perm_Descripcion { get; set; }
        public string Perm_Controlador { get; set; }
        public string Perm_Action { get; set; }
        public string Perm_UsuarioCreacion { get; set; }
        public DateTime? Perm_FechaCreacion { get; set; }
        public string Perm_UsuarioModifica { get; set; }
        public DateTime? Perm_FechaModifica { get; set; }
        public bool? Perm_Estado { get; set; }
    }
}
