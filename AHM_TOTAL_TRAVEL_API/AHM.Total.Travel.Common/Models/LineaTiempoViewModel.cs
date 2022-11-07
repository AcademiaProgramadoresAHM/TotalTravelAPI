using AHM.Total.Travel.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.Common.Models
{
    public class LineaTiempoViewModel
    {
        public Object Actividades { get; set; }
        public  LineaTiempoHotelesViewModel Hotel_Info {get; set;}

        public LineaTiempoTransportesViewModel Transporte_Info { get; set; }
        public LineaTiempoUsuariosViewModel Cliente_Info { get; set; }

    }

    public class LineaTiempoActividadesViewModel
    {
        public int ID { get; set; }
        public string Actividad { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class LineaTiempoHotelesViewModel
    {
        public int ID_Hotel { get; set; }
        public string Hotel { get; set; }
        public DateTime? Fecha_Entrada { get; set; }
        public DateTime? Fecha_Salida { get; set; }
    }

    public class LineaTiempoTransportesViewModel
    {
        public int ID_Transporte { get; set; }
        public string Transporte { get; set; }
        public string HoraSalida { get; set; }
        public string HoraLlegada { get; set; }
        
    }

    public class LineaTiempoUsuariosViewModel
    {
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
    }
    
}
