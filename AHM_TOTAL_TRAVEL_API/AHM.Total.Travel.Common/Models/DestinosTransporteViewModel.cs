using AHM.Total.Travel.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class DestinosTransporteViewModel
    {
        public int? DsTr_CiudadSalida { get; set; }
        public int? DsTr_CiudadDestino { get; set; }
        public int? DsTr_UsuarioCreacion { get; set; }
        public int? DsTr_UsuarioModifica { get; set; }
        public int? Partner_ID { get; set; }
    }
}
