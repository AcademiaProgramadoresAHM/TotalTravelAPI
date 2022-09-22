using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class UsuariosViewModel
    {
        public int ID { get; set; }
        public string DNI { get; set; }
        public string nombre_completo { get; set; }
        public string Genero { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Partner { get; set; }
        public string Rol { get; set; }
        public int? ID_Crea { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public int? ID_Modifica { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? Fecha_Modifica { get; set; }
        public bool? Estado { get; set; }
    }
}
