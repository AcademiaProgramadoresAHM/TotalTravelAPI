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

        #region Tipos Pagos

        public static string UDP_tbTiposPagos_INSERT = "Trpt.UDP_tbTiposPagos_INSERT";
        public static string UDP_tbTiposPagos_UPDATE = "Trpt.UDP_tbTiposPagos_UPDATE";
        public static string UDP_tbTiposPagos_DELETE = "Trpt.UDP_tbTiposPagos_DELETE";
        //public static string UDP_tbTiposPagos_FIND = "Trpt.UDP_tbTiposPagos_FIND";

        #endregion

        #region Permisos

        public static string UDP_tbPermisos_Insert = "Acce.UDP_tbPermisos_INSERT";

        public static string UDP_tbPermisos_Update = "Acce.UDP_tbPermisos_UPDATE";

        public static string UDP_tbPermisos_Delete = "Acce.UDP_tbPermisos_DELETE";

        public static string UDP_tbPermisos_Find = "Acce.UDP_tbPermisos_FIND";


        #endregion

        #region Roles

        public static string UDP_tbRoles_Insert = "Acce.UDP_tbRoles_Insert";

        public static string UDP_tbRoles_Update = "Acce.UDP_tbRoles_Update";

        public static string UDP_tbRoles_Delete = "Acce.UDP_tbRoles_Delete";

        public static string UDP_tbRoles_Find = "Acce.UDP_tbRoles_Find";

        #endregion

        #region RolesPermisos

        public static string UDP_tbRolesPermisos_Insert = "Acce.UDP_tbRolesPermisos_Insert";

        public static string UDP_tbRolesPermisos_Update = "Acce.UDP_tbRolesPermisos_Update";

        public static string UDP_tbRolesPermisos_Delete = "Acce.UDP_tbRolesPermisos_Delete";

        public static string UDP_tbRolesPermisos_Find = "Acce.UDP_tbRolesPermisos_Find";

        #endregion

    }
}
