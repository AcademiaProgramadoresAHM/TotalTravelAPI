using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Text.Json.Serialization;

namespace AHM.Total.Travel.Common.SecurityModels
{
    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class UserLoggedModel
    {
        public int ID { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public int Role_ID { get; set; }
        public string Partner { get; set; }
        public int? PartnerID { get; set; }
        public string Token { get; set; }
    }

    public class RefreshToken
    {
        public int ID { get; set; }
        public int? Usua_ID { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }
        public bool isActive => Revoked == null && !IsExpired;

    }
    public class RefreshAccessToken
    {
        public string Token { get; set; }
    }
}
