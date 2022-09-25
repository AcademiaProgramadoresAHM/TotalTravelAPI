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

        #region Actividades
        public static string UDP_tbActividades_Insert = "Actv.UDP_tbActividades_Insert";

        public static string UDP_tbActividades_Update = "Actv.UDP_tbActividades_Update";

        public static string UDP_tbActividades_Delete = "Actv.UDP_tbActividades_Delete";

        #endregion

        #region Usuarios
        public static string UDP_tbUsuarios_Insert = "Acce.UDP_tbUsuarios_Insert";

        public static string UDP_tbUsuarios_Update = "Acce.UDP_tbUsuarios_Update";
        
        public static string UDP_tbUsuarios_Delete = "Acce.UDP_tbUsuarios_Delete";


        #endregion

        #region ActividadesExtras
        public static string UDP_tbActividadesExtra_Delete = "Actv.UDP_tbActividadesExtra_Delete";

        public static string UDP_tbActividadesExtra_Insert = "Actv.UDP_tbActividadesExtra_Insert";

        public static string UDP_tbActividadesExtra_Update = "Actv.UDP_tbActividadesExtra_Update";

        #endregion

        #region Direcciones
        public static string UDP_tbDirecciones_Insert = "Gene.UDP_tbDirecciones_Insert";

        public static string UDP_tbDirecciones_Update = "Gene.UDP_tbDirecciones_Update";

        public static string UDP_tbDirecciones_Delete = "Gene.UDP_tbDirecciones_Delete";

        public static string UDP_tbDirecciones_Find = "Gene.UDP_tbDirecciones_Find";
        #endregion

        #region TiposActividades
        public static string UDP_tbTiposActividades_Insert = "Actv.UDP_tbTiposActividades_Insert";

        public static string UDP_tbTiposActividades_Update = "Actv.UDP_tbTiposActividades_Update";

        public static string UDP_tbTiposActividades_Delete = "Actv.UDP_tbTiposActividades_Delete";

        public static string UDP_tbTiposActividades_Find = "Actv.UDP_tbTiposActividades_Find";
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

        public static string UDP_tbRoles_Find = "Acce.tbRoles_Find";

        #endregion

        #region RolesPermisos

        public static string UDP_tbRolesPermisos_Insert = "Acce.UDP_tbRolesPermisos_Insert";

        public static string UDP_tbRolesPermisos_Update = "Acce.UDP_tbRolesPermisos_Update";

        public static string UDP_tbRolesPermisos_Delete = "Acce.UDP_tbRolesPermisos_Delete";

        public static string UDP_tbRolesPermisos_Find = "Acce.UDP_tbRolesPermisos_Find";

        #endregion

        #region TiposTransportes

        public static string UDP_tbTiposTransportes_Insert = "Trpt.UDP_tbTiposTransportes_Insert";

        public static string UDP_tbTiposTransportes_Update = "Trpt.UDP_tbTiposTransportes_Update";

        public static string UDP_tbTiposTransportes_Delete = "Trpt.UDP_tbTiposTransportes_Delete";

        #endregion

        #region DestinosTransportes

        public static string UDP_tbDestinosTransportes_Insert = "Trpt.UDP_tbDestinosTransportes_Insert";

        public static string UDP_tbDestinosTransportes_Update = "Trpt.UDP_tbDestinosTransportes_Update";

        public static string UDP_tbDestinosTransportes_Delete = "Trpt.UDP_tbDestinosTransportes_Delete";

        #endregion

        #region HorariosTransportes

        public static string UDP_tbHorariosTransportes_Insert = "Trpt.UDP_tbHorariosTransportes_Insert";

        public static string UDP_tbHorariosTransportes_Update = "Trpt.UDP_tbHorariosTransportes_Update";

        public static string UDP_tbHorariosTransportes_Delete = "Trpt.UDP_tbHorariosTransportes_Delete";

        #endregion

        #region DetallesTransportes

        public static string UDP_tbDetallesTransportes_Insert = "Trpt.UDP_tbDetallesTransportes_Insert";

        public static string UDP_tbDetallesTransportes_Update = "Trpt.UDP_tbDetallesTransportes_Update";

        public static string UDP_tbDetallesTransportes_Delete = "Trpt.UDP_tbDetallesTransportes_Delete";

        #endregion

        #region Paises
        public static string UDP_tbPaises_Insert = "Gene.UDP_tblPaises_Insert";

        public static string UDP_tbPaises_Update = "Gene.UDP_tblPaises_Update";

        public static string UDP_tbPaises_Delete = "Gene.UDP_tblPaises_Delete";

        //public static string UDP_tbPaises_Find = "Gene.UDP_tblPaises_Find";
        #endregion

        #region Partners
        public static string UDP_tbPartners_Insert = "Gene.UDP_tbPartners_Insert";

        public static string UDP_tbPartners_Update = "Gene.UDP_tbPartners_Update";

        public static string UDP_tbPartners_Delete = "Gene.UDP_tbPartners_Delete";

        //public static string UDP_tbPartners_Find = "Gene.UDP_tbPartners_Find";
        #endregion

        #region CategoriasHabitaciones
        public static string UDP_tbCategoriasHabitaciones_Insert = "Htel.UDP_tbCategoriasHabitaciones_Insert";

        public static string UDP_tbCategoriasHabitaciones_Update = "Htel.UDP_tbCategoriasHabitaciones_Update";

        public static string UDP_tbCategoriasHabitaciones_Delete = "Htel.UDP_tbCategoriasHabitaciones_Delete";

        public static string UDP_tbCategoriasHabitaciones_Find = "Htel.UDP_tbCategoriasHabitaciones_Find";
        #endregion

        #region PaquetePredeterminadosDetalles
        public static string UDP_tbPaquetePredeterminadosDetalles_Insert = "Sale.UDP_tbPaquetePredeterminadosDetalles_INSERT";

        public static string UDP_tbPaquetePredeterminadosDetalles_Update = "Sale.UDP_tbPaquetePredeterminadosDetalles_UPDATE";

        public static string UDP_tbPaquetePredeterminadosDetalles_Delete = "Sale.UDP_tbPaquetePredeterminadosDetalles_DELETE";
        #endregion

        #region ReservacionesActividadesExtras
        public static string UDP_tbReservacionesActividadesExtras_Insert = "Resv.UDP_tbReservacionesActividadesExtras_Insert";

        public static string UDP_tbReservacionesActividadesExtras_Update = "Resv.UDP_tbReservacionesActividadesExtras_Update";

        public static string UDP_tbReservacionesActividadesExtras_Delete = "Resv.UDP_tbReservacionesActividadesExtras_Delete";
        #endregion

        #region ReservacionesActividadesHoteles
        public static string UDP_tbReservacionesActividadesHoteles_Insert = "Resv.UDP_tbReservacionesActividadesHoteles_Insert";

        public static string UDP_tbReservacionesActividadesHoteles_Update = "Resv.UDP_tbReservacionesActividadesHoteles_Update";

        public static string UDP_tbReservacionesActividadesHoteles_Delete = "Resv.UDP_tbReservacionesActividadesHoteles_Delete";
        #endregion

        #region ReservacionesHoteles
            public static string UDP_tbReservacionesHoteles_DELETE = "Resv.UDP_tbReservacionesHoteles_DELETE";
            public static string UDP_tbReservacionesHoteles_INSERT = "Resv.UDP_tbReservacionesHoteles_INSERT";
            public static string UDP_tbReservacionesHoteles_UPDATE = "Resv.UDP_tbReservacionesHoteles_UPDATE";
        #endregion

        #region ReservacionesDetalles
        public static string UDP_tbReservacionesDetalles_Insert = "Resv.UDP_tbReservacionesDetalles_Insert";

        public static string UDP_tbReservacionesDetalles_Update = "Resv.UDP_tbReservacionesDetalles_Update";

        public static string UDP_tbReservacionesDetalles_Find = "Resv.UDP_tbReservacionesDetalles_Find";

        public static string UDP_tbReservacionesDetalles_Delete = "Resv.UDP_tbReservacionesDetalles_Delete";
        #endregion

        #region TiposMenu 
            public static string UDP_tbTipoMenus_Delete = "Rest.UDP_tbTipoMenus_Delete";
            public static string UDP_tbTipoMenus_Insert = "Rest.UDP_tbTipoMenus_Insert";
            public static string UDP_tbTipoMenus_Update = "Rest.UDP_tbTipoMenus_Update";
        #endregion

        #region Restaurantes 
        public static string UDP_tbRestaurantes_Delete = "Rest.UDP_tbRestaurantes_Delete";
        public static string UDP_tbRestaurantes_Insert = "Rest.UDP_tbRestaurantes_Insert";
        public static string UDP_tbRestaurantes_Update = "Rest.UDP_tbRestaurantes_Update";
        #endregion

        #region Menus 
        public static string UDP_tbMenu_Delete = "Rest.UDP_tbMenu_Delete";
        public static string UDP_tbMenu_Insert = "Rest.UDP_tbMenu_Insert";
        public static string UDP_tbMenu_Update = "Rest.UDP_tbMenu_Update";
        #endregion

        #region RegistrosPagos
        public static string UDP_tbRegistrosPagos_Delete = "Resv.UDP_tbRegistrosPagos_Delete";
            public static string UDP_tbRegistrosPagos_Insert = "Resv.UDP_tbRegistrosPagos_Insert";
        #endregion

        #region Reservaciones
            public static string UDP_tbReservaciones_Delete = "Resv.UDP_tbReservaciones_Delete";
            public static string UDP_tbReservaciones_Insert = "Resv.UDP_tbReservaciones_Insert";
            public static string UDP_tbReservaciones_Update = "Resv.UDP_tbReservaciones_Update"; 
             public static string UDP_tbReservaciones_Confirmaciones = "Resv.UDP_tbReservaciones_Confirmaciones";
        #endregion

        #region Habitaciones
        public static string UDP_tbHabitaciones_Insert = "Htel.UDP_tbHabitaciones_Insert";

        public static string UDP_tbHabitaciones_Update = "Htel.UDP_tbHabitaciones_Update";

        public static string UDP_tbHabitaciones_Delete = "Htel.UDP_tbHabitaciones_Delete";


        #endregion

        #region Hoteles
        public static string UDP_tbHoteles_Insert = "Htel.UDP_tbHoteles_Insert";

        public static string UDP_tbHoteles_Update = "Htel.UDP_tbHoteles_Update";

        public static string UDP_tbHoteles_Delete = "Htel.UDP_tbHoteles_Delete";

        #endregion

        #region HotelesMenus 
        public static string UDP_tbHotelesMenus_Delete = "Htel.UDP_tbHotelesMenus_Delete";
        public static string UDP_tbHotelesMenus_Insert = "Htel.UDP_tbHotelesMenus_Insert";
        public static string UDP_tbHotelesMenus_Update = "Htel.UDP_tbHotelesMenus_Update";
        #endregion

        #region HotelesActividades
        public static string UDP_tbHotelesActividades_Insert = "Htel.UDP_tbHotelesActividades_Insert";

        public static string UDP_tbHotelesActividades_Update = "Htel.UDP_tbHotelesActividades_Update";

        public static string UDP_tbHotelesActividades_Delete = "Htel.UDP_tbHotelesActividades_Delete";

        #endregion
    }
}
