﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class tbUsuariosLogins
    {
        public int ID { get; set; }
        public int? Usua_ID { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? Expires { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Revoked { get; set; }
        public bool? isActive { get; set; }
    }
}