﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class UsuariosViewModel
    {
        public int Usua_ID { get; set; }
        public string Usua_DNI { get; set; }
        public string Usua_Nombre { get; set; }
        public string Usua_Apellido { get; set; }
        public DateTime? Usua_FechaNaci { get; set; }
        public string Usua_Email { get; set; }
        public string Usua_Sexo { get; set; }
        public string Usua_Telefono { get; set; }
        public string Usua_Url { get; set; }
        public string Usua_Password { get; set; }
        public int? Usua_esAdmin { get; set; }
        public string Usua_Salt { get; set; }
        public int? Role_ID { get; set; }
        public int? Dire_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Usua_UsuarioCreacion { get; set; }
        public int? Usua_UsuarioModifica { get; set; }
        public IFormFile File { get; set; }

    }
    public class UsuariosPasswordViewModel
    {
        public int Usua_ID { get; set; }
        public string Usua_DNI { get; set; }
        public string Usua_Nombre { get; set; }
        public string Usua_Apellido { get; set; }
        public DateTime? Usua_FechaNaci { get; set; }
        public string Usua_Email { get; set; }
        public string Usua_Sexo { get; set; }
        public string Usua_Telefono { get; set; }
        public string Usua_Url { get; set; }
        public string Usua_Password { get; set; }
        public int? Usua_esAdmin { get; set; }
        public string Usua_Salt { get; set; }
        public int? Role_ID { get; set; }
        public int? Dire_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Usua_UsuarioCreacion { get; set; }
        public int? Usua_UsuarioModifica { get; set; }

    }
    public class UsuariosInsertViewModel
    {
        public string Usua_DNI { get; set; }
        public string Usua_Nombre { get; set; }
        public string Usua_Apellido { get; set; }
        public DateTime? Usua_FechaNaci { get; set; }
        public string Usua_Email { get; set; }
        public string Usua_Sexo { get; set; }
        public string Usua_Telefono { get; set; }
        public string Usua_Url { get; set; }
        public string Usua_Password { get; set; }
        public int? Usua_esAdmin { get; set; }
        public int? Role_ID { get; set; }
        public int? Dire_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Usua_UsuarioCreacion { get; set; }
        public List<IFormFile> File { get; set; }

    }
    public class UsuariosUpdateViewModel
    {
        public string Usua_DNI { get; set; }
        public string Usua_Nombre { get; set; }
        public string Usua_Apellido { get; set; }
        public string Usua_Telefono { get; set; }
        public List<IFormFile> Usua_Url { get; set; }
        public int? Role_ID { get; set; }
        public int? Dire_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Usua_UsuarioModifica { get; set; }

    }
    public class UsuariosListViewModel
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
