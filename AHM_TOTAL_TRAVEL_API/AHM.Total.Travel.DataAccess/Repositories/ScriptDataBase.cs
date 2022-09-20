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
    }
}
