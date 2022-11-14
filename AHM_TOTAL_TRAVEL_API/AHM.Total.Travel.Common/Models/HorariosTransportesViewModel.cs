using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class HorariosTransportesViewModel
    {
        public int? DsTr_ID { get; set; }
        public int? Partner_ID { get; set; }
        public DateTime? HoTr_Fecha { get; set; }
        public string HoTr_HoraSalida { get; set; }
        public string HoTr_HoraLlegada { get; set; }
        public int? HoTr_UsuarioCreacion { get; set; }
        public int? HoTr_UsuarioModifica { get; set; }
    }
}
