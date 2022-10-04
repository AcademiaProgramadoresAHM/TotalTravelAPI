using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class DetallesTransportesViewModel
    {
        public int? Tprt_ID { get; set; }
        public int? HoTr_ID { get; set; }
        public int? DeTr_Capacidad { get; set; }
        public decimal? DeTr_Precio { get; set; }
        public string DeTr_Matricula { get; set; }
        public int? DeTr_UsuarioCreacion { get; set; }
        public int? DeTr_UsuarioModifica { get; set; }

    }
}
