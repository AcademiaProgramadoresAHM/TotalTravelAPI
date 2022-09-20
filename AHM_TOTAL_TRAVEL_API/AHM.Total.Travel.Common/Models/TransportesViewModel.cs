﻿using AHM.Total.Travel.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

        public virtual tbDirecciones Dire { get; set; }
        public virtual tbPartners Part { get; set; }
        public virtual tbTiposTransportes Tprt { get; set; }
        public virtual tbUsuarios Tprt_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Tprt_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbDetallesTransportes> tbDetallesTransportes { get; set; }
    }
}
