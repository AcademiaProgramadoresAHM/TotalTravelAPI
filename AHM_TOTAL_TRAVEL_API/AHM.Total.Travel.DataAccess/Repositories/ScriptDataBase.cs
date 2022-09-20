using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.DataAccess.Repositories
{
    public class ScriptDataBase
    {
        #region Ciudades
        public static string UDP_tbCiudades_Insert = "Gene.UDP_tbCiudades_Insert";

        public static string UDP_tbCiudades_Update = "Gene.UDP_tbCiudades_Update";

        public static string UDP_tbCiudades_Delete = "Gene.UDP_tbCiudades_Delete";

        public static string UDP_tbCiudades_Find = "Gene.UDP_tbCiudades_Find";
        #endregion

        #region Transportes

        public static string UDP_tbTransportes_Insert = "Trpt.UDP_tbTransportes_Insert";
        public static string UDP_tbTransportes_Update = "Trpt.UDP_tbTransportes_Update";
        public static string UDP_tbTransportes_Delete = "Trpt.UDP_tbTransportes_Delete";
        public static string UDP_tbTransportes_Find = "Trpt.UDP_tbTransportes_Find";

        #endregion


        #region RestauranteReservaciones
        public static string UDP_tbReservacionRestaurantes_Insert = "Resv.UDP_tbReservacionRestaurantes_Insert";

        public static string UDP_tbReservacionRestaurantes_Update = "Resv.UDP_tbReservacionRestaurantes_Update";

        public static string UDP_tbReservacionRestaurantes_Delete = "Resv.UDP_tbReservacionRestaurantes_Delete";

        public static string UDP_tbReservacionRestaurantes_Find = "Resv.UDP_tbReservacionRestaurantes_Find";
        #endregion



        #region ReservacionTransporte
        public static string UDP_tbReservacionTransporte_Insert = "Resv.UDP_tbReservacionTransporte_Insert";

        public static string UDP_tbReservacionTransporte_Update = "Resv.UDP_tbReservacionTransporte_Update";

        public static string UDP_tbReservacionTransporte_Delete = "Resv.UDP_tbReservacionTransporte_Delete";

        public static string UDP_tbReservacionTransporte_Find = "Resv.UDP_tbReservacionTransporte_Find";
        #endregion

        #region PaquetePredeterminado
        public static string UDP_tbPaquetePredeterminado_INSERT = "Sale.UDP_tbPaquetePredeterminado_INSERT";

        public static string UDP_tbPaquetePredeterminado_UPDATE = "Sale.UDP_tbPaquetePredeterminado_UPDATE";

        public static string UDP_tbPaquetePredeterminado_DELETE = "Sale.UDP_tbPaquetePredeterminado_DELETE";

        public static string UDP_tbPaquetePredeterminado_Find = "Sale.UDP_tbPaquetePredeterminado_Find";
        #endregion

    }
}
