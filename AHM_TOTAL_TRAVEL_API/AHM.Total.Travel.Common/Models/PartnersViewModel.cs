using System;

namespace AHM.Total.Travel.Common.Models
{
    public class PartnersViewModel
    {
        public int Part_ID { get; set; }
        public string Part_Nombre { get; set; }
        public string Part_Email { get; set; }
        public string Part_Telefono { get; set; }
        public int? TiPart_Id { get; set; }
        public int? Part_UsuarioCreacion { get; set; }
        public DateTime? Part_FechaCreacion { get; set; }
        public int? Part_UsuarioModifica { get; set; }
        public DateTime? Part_FechaModifica { get; set; }
        public bool? Part_Estado { get; set; }
        public string Part_Url { get; set; }
    }
}
