﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class VW_tbUsuarios
    {
        public int ID { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nombrecompleto { get; set; }
        public string Sexo { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int DireccionID { get; set; }
        public int ColoniaID { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Avenida { get; set; }
        public string Partner { get; set; }
        public int? PartnerID { get; set; }
        public string Rol { get; set; }
        public int Role_ID { get; set; }
        public int? ID_Crea { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public int? ID_Modifica { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? Fecha_Modifica { get; set; }
        public bool? Estado { get; set; }
        public string Image_URL { get; set; }
    }
}