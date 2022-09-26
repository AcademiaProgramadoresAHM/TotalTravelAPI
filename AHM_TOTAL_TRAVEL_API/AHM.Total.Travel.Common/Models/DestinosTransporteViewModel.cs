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

    }
}
