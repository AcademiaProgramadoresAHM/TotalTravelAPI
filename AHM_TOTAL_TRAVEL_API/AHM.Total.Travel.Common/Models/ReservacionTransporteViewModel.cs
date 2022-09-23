using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ReservacionTransporteViewModel
    {
        public int ReTr_ID { get; set; }
        public int? Detr_ID { get; set; }
        public int? Resv_ID { get; set; }
        public int? ReTr_CantidadAsientos { get; set; }
        public bool? ReTr_Cancelado { get; set; }
        public DateTime? ReTr_FechaCancelado { get; set; }
        public int? ReTr_UsuarioCreacion { get; set; }
        public DateTime? ReTr_FechaCreacion { get; set; }
        public int? ReTr_UsuarioModifica { get; set; }
        public DateTime? ReTr_FechaModifica { get; set; }
        public bool? ReTr_Estado { get; set; }
    }
}
