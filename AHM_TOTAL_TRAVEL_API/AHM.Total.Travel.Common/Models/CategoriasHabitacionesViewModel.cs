using AHM.Total.Travel.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class CategoriasHabitacionesViewModel
    {
        public int CaHa_ID { get; set; }
        public string CaHa_Descripcion { get; set; }
        public int? CaHa_UsuarioCreacion { get; set; }
        public DateTime? CaHa_FechaCreacion { get; set; }
        public int? CaHa_UsuarioModifica { get; set; }
        public DateTime? CaHa_FechaModifica { get; set; }
        public bool? CaHa_Estado { get; set; }
    }
}
