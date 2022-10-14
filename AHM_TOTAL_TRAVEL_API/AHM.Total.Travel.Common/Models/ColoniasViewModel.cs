using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class ColoniasViewModel
    {
        public int Colo_ID { get; set; }
        public string Colo_Descripcion { get; set; }
        public int? Ciud_ID { get; set; }
        public int? Colo_UsuarioCreacion { get; set; }
        public int? Colo_UsuarioModifica { get; set; }
    }
}
