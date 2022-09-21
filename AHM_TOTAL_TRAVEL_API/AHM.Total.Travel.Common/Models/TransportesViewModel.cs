using System;

namespace AHM.Total.Travel.Common.Models
{
    public class TransportesViewModel
    {
        public int Tprt_ID { get; set; }
        public int? TiTr_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Dire_ID { get; set; }
        public int? Tprt_UsuarioCreacion { get; set; }
        public DateTime? Tprt_FechaCreacion { get; set; }
        public int? Tprt_UsuarioModifica { get; set; }
        public DateTime? Tprt_FechaModifica { get; set; }
        public bool? Tprt_Estado { get; set; }

    }
}
