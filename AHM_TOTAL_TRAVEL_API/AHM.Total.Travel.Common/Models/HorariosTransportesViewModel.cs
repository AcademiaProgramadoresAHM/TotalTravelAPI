using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class HorariosTransportesViewModel
    {
        public int HoTr_ID { get; set; }
        public int? DsTr_ID { get; set; }
        public DateTime? HoTr_Fecha { get; set; }
        public string HoTr_HoraSalida { get; set; }
        public string HoTr_HoraLlegada { get; set; }
        public int? HoTr_UsuarioCreacion { get; set; }
        public DateTime? HoTr_FechaCreacion { get; set; }
        public int? HoTr_UsuarioModifica { get; set; }
        public DateTime? HoTr_FechaModifica { get; set; }
        public bool? HoTr_Estado { get; set; }
    }
}
