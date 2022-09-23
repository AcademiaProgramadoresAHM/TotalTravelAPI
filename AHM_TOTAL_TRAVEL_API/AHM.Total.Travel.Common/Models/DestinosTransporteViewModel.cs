using AHM.Total.Travel.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class DestinosTransporteViewModel
    {
        public int DsTr_ID { get; set; }
        public int? DsTr_CiudadSalida { get; set; }
        public int? DsTr_CiudadDestino { get; set; }
        public int? DsTr_UsuarioCreacion { get; set; }
        public DateTime? DsTr_FechaCreacion { get; set; }
        public int? DsTr_UsuarioModifica { get; set; }
        public DateTime? DsTr_FechaModifica { get; set; }
        public bool? DsTr_Estado { get; set; }

        public virtual tbCiudades DsTr_CiudadDestinoNavigation { get; set; }
        public virtual tbCiudades DsTr_CiudadSalidaNavigation { get; set; }
        public virtual tbUsuarios DsTr_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios DsTr_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbHorariosTransportes> tbHorariosTransportes { get; set; }
    }
}
