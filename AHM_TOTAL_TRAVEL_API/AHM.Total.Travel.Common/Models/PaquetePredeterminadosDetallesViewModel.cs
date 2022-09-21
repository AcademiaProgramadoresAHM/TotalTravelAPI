using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class PaquetePredeterminadosDetallesViewModel
    {
        public int ID { get; set; }
        public int PaqueteID { get; set; }
        public string NombrePaquete { get; set; }
        public string DescripcionPaquete { get; set; }
        public string DuracionPaquete { get; set; }
        public int ActividadID { get; set; }
        public string DescripcionActividad { get; set; }
        public int? UsuarioCreacionID { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? UsuarioModificaID { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public bool? Estado { get; set; }
    }
}
