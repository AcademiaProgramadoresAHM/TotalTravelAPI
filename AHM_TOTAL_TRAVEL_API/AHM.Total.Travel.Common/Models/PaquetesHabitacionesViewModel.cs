using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class PaquetesHabitacionesViewModel
    {
        public int PaHa_Id { get; set; }
        public int? Paqu_Id { get; set; }
        public int? Habi_Id { get; set; }
        public int? PaHa_UsuarioCreacion { get; set; }
        public DateTime? PaHa_FechaCreacion { get; set; }
        public int? PaHa_UsuarioModifica { get; set; }
        public DateTime? PaHa_FechaModifica { get; set; }
        public bool? PaHa_Estado { get; set; }
    }
}
