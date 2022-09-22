using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ActividadesExtrasViewModel
    {
        public int ID { get; set; }
        public string Partner { get; set; }
        public string Actividad { get; set; }
        public decimal? Precio { get; set; }
        public string Descripcion { get; set; }
        public int? ID_Crea { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? ID_Modifica { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public bool? Estado { get; set; }
    }
}
