﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AHM.Total.Travel.Entities.Entities
{
    public partial class tbUsuarios
    {
        public tbUsuarios()
        {
            InverseUsua_UsuarioCreacionNavigation = new HashSet<tbUsuarios>();
            InverseUsua_UsuarioModificaNavigation = new HashSet<tbUsuarios>();
            tbActividadesActv_UsuarioCreacionNavigation = new HashSet<tbActividades>();
            tbActividadesActv_UsuarioModificaNavigation = new HashSet<tbActividades>();
            tbActividadesExtrasAcEx_UsuarioCreacionNavigation = new HashSet<tbActividadesExtras>();
            tbActividadesExtrasAcEx_UsuarioModificaNavigation = new HashSet<tbActividadesExtras>();
            tbCategoriasHabitacionesCaHa_UsuarioCreacionNavigation = new HashSet<tbCategoriasHabitaciones>();
            tbCategoriasHabitacionesCaHa_UsuarioModificaNavigation = new HashSet<tbCategoriasHabitaciones>();
            tbColoniasColo_UsuarioCreacionNavigation = new HashSet<tbColonias>();
            tbColoniasColo_UsuarioModificaNavigation = new HashSet<tbColonias>();
            tbDestinosTransportesDsTr_UsuarioCreacionNavigation = new HashSet<tbDestinosTransportes>();
            tbDestinosTransportesDsTr_UsuarioModificaNavigation = new HashSet<tbDestinosTransportes>();
            tbDetallesTransportesDeTr_UsuarioCreacionNavigation = new HashSet<tbDetallesTransportes>();
            tbDetallesTransportesDeTr_UsuarioModificaNavigation = new HashSet<tbDetallesTransportes>();
            tbDireccionesDire_UsuarioCreacionNavigation = new HashSet<tbDirecciones>();
            tbDireccionesDire_UsuarioModificaNavigation = new HashSet<tbDirecciones>();
            tbHabitacionesHabi_UsuarioCreacionNavigation = new HashSet<tbHabitaciones>();
            tbHabitacionesHabi_UsuarioModificaNavigation = new HashSet<tbHabitaciones>();
            tbHorariosTransportesHoTr_UsuarioCreacionNavigation = new HashSet<tbHorariosTransportes>();
            tbHorariosTransportesHoTr_UsuarioModificaNavigation = new HashSet<tbHorariosTransportes>();
            tbHotelesActividadesHoAc_UsuarioCreacionNavigation = new HashSet<tbHotelesActividades>();
            tbHotelesActividadesHoAc_UsuarioModificaNavigation = new HashSet<tbHotelesActividades>();
            tbHotelesHote_UsuarioCreacionNavigation = new HashSet<tbHoteles>();
            tbHotelesHote_UsuarioModificaNavigation = new HashSet<tbHoteles>();
            tbHotelesMenusHoMe_UsuarioCreacionNavigation = new HashSet<tbHotelesMenus>();
            tbHotelesMenusHoMe_UsuarioModificaNavigation = new HashSet<tbHotelesMenus>();
            tbMenusMenu_UsuarioCreacionNavigation = new HashSet<tbMenus>();
            tbMenusMenu_UsuarioModificaNavigation = new HashSet<tbMenus>();
            tbPaisesPais_UsuarioCreacionNavigation = new HashSet<tbPaises>();
            tbPaisesPais_UsuarioModificaNavigation = new HashSet<tbPaises>();
            tbPaquetePredeterminadosActividadesHotelesPaAc_UsuarioCreacionNavigation = new HashSet<tbPaquetePredeterminadosActividadesHoteles>();
            tbPaquetePredeterminadosActividadesHotelesPaAc_UsuarioModificaNavigation = new HashSet<tbPaquetePredeterminadosActividadesHoteles>();
            tbPaquetePredeterminadosDetallesPaDe_UsuarioCreacionNavigation = new HashSet<tbPaquetePredeterminadosDetalles>();
            tbPaquetePredeterminadosDetallesPaDe_UsuarioModificaNavigation = new HashSet<tbPaquetePredeterminadosDetalles>();
            tbPaquetePredeterminadosPaqu_UsuarioCreacionNavigation = new HashSet<tbPaquetePredeterminados>();
            tbPaquetePredeterminadosPaqu_UsuarioModificaNavigation = new HashSet<tbPaquetePredeterminados>();
            tbPaquetesHabitacionesPaHa_UsuarioCreacionNavigation = new HashSet<tbPaquetesHabitaciones>();
            tbPaquetesHabitacionesPaHa_UsuarioModificaNavigation = new HashSet<tbPaquetesHabitaciones>();
            tbPartnersPart_UsuarioCreacionNavigation = new HashSet<tbPartners>();
            tbPartnersPart_UsuarioModificaNavigation = new HashSet<tbPartners>();
            tbPermisosPerm_UsuarioCreacionNavigation = new HashSet<tbPermisos>();
            tbPermisosPerm_UsuarioModificaNavigation = new HashSet<tbPermisos>();
            tbRegistrosPagosRePa_UsuarioCreacionNavigation = new HashSet<tbRegistrosPagos>();
            tbRegistrosPagosRePa_UsuarioModificaNavigation = new HashSet<tbRegistrosPagos>();
            tbReservacionTransporteReTr_UsuarioCreacionNavigation = new HashSet<tbReservacionTransporte>();
            tbReservacionTransporteReTr_UsuarioModificaNavigation = new HashSet<tbReservacionTransporte>();
            tbReservacionesActividadesExtrasReAE_UsuarioCreacionNavigation = new HashSet<tbReservacionesActividadesExtras>();
            tbReservacionesActividadesExtrasReAE_UsuarioModificaNavigation = new HashSet<tbReservacionesActividadesExtras>();
            tbReservacionesActividadesHotelesReAH_UsuarioCreacionNavigation = new HashSet<tbReservacionesActividadesHoteles>();
            tbReservacionesActividadesHotelesReAH_UsuarioModificaNavigation = new HashSet<tbReservacionesActividadesHoteles>();
            tbReservacionesDetallesReDe_UsuarioCreacionNavigation = new HashSet<tbReservacionesDetalles>();
            tbReservacionesDetallesReDe_UsuarioModificaNavigation = new HashSet<tbReservacionesDetalles>();
            tbReservacionesHotelesReHo_UsuarioCreacionNavigation = new HashSet<tbReservacionesHoteles>();
            tbReservacionesHotelesReHo_UsuarioModificaNavigation = new HashSet<tbReservacionesHoteles>();
            tbReservacionesResv_UsuarioCreacionNavigation = new HashSet<tbReservaciones>();
            tbReservacionesResv_UsuarioModificaNavigation = new HashSet<tbReservaciones>();
            tbReservacionesUsua_ = new HashSet<tbReservaciones>();
            tbRestaurantesRest_UsuarioCreacionNavigation = new HashSet<tbRestaurantes>();
            tbRestaurantesRest_UsuarioModificaNavigation = new HashSet<tbRestaurantes>();
            tbRolesRole_UsuarioCreacionNavigation = new HashSet<tbRoles>();
            tbRolesRole_UsuarioModificaNavigation = new HashSet<tbRoles>();
            tbTipoMenusTime_UsuarioCreacionNavigation = new HashSet<tbTipoMenus>();
            tbTipoMenusTime_UsuarioModificaNavigation = new HashSet<tbTipoMenus>();
            tbTipoPartnersTiPar_UsuarioCreacionNavigation = new HashSet<tbTipoPartners>();
            tbTipoPartnersTiPar_UsuarioModificaNavigation = new HashSet<tbTipoPartners>();
            tbTiposActividadesTiAc_UsuarioCreacionNavigation = new HashSet<tbTiposActividades>();
            tbTiposActividadesTiAc_UsuarioModificaNavigation = new HashSet<tbTiposActividades>();
            tbTiposPagosTiPa_UsuarioCreacionNavigation = new HashSet<tbTiposPagos>();
            tbTiposPagosTiPa_UsuarioModificaNavigation = new HashSet<tbTiposPagos>();
            tbTiposTransportesTiTr_UsuarioCreacionNavigation = new HashSet<tbTiposTransportes>();
            tbTiposTransportesTiTr_UsuarioModificaNavigation = new HashSet<tbTiposTransportes>();
            tbTransportesTprt_UsuarioCreacionNavigation = new HashSet<tbTransportes>();
            tbTransportesTprt_UsuarioModificaNavigation = new HashSet<tbTransportes>();
        }

        public int Usua_ID { get; set; }
        public string Usua_DNI { get; set; }
        public string Usua_Url { get; set; }
        public string Usua_Nombre { get; set; }
        public string Usua_Apellido { get; set; }
        public DateTime? Usua_FechaNaci { get; set; }
        public string Usua_Email { get; set; }
        public string Usua_Sexo { get; set; }
        public string Usua_Telefono { get; set; }
        public string Usua_Password { get; set; }
        public bool? Usua_esAdmin { get; set; }
        public string Usua_Salt { get; set; }
        public int? Role_ID { get; set; }
        public int? Dire_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? Usua_UsuarioCreacion { get; set; }
        public DateTime? Usua_FechaCreacion { get; set; }
        public int? Usua_UsuarioModifica { get; set; }
        public DateTime? Usua_FechaModifica { get; set; }
        public bool? Usua_Estado { get; set; }

        public virtual tbDirecciones Dire_ { get; set; }
        public virtual tbPartners Part_ { get; set; }
        public virtual tbRoles Role_ { get; set; }
        public virtual tbUsuarios Usua_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Usua_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbUsuarios> InverseUsua_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbUsuarios> InverseUsua_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbActividades> tbActividadesActv_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbActividades> tbActividadesActv_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbActividadesExtras> tbActividadesExtrasAcEx_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbActividadesExtras> tbActividadesExtrasAcEx_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbCategoriasHabitaciones> tbCategoriasHabitacionesCaHa_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbCategoriasHabitaciones> tbCategoriasHabitacionesCaHa_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbColonias> tbColoniasColo_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbColonias> tbColoniasColo_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbDestinosTransportes> tbDestinosTransportesDsTr_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbDestinosTransportes> tbDestinosTransportesDsTr_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbDetallesTransportes> tbDetallesTransportesDeTr_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbDetallesTransportes> tbDetallesTransportesDeTr_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbDirecciones> tbDireccionesDire_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbDirecciones> tbDireccionesDire_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbHabitaciones> tbHabitacionesHabi_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbHabitaciones> tbHabitacionesHabi_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbHorariosTransportes> tbHorariosTransportesHoTr_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbHorariosTransportes> tbHorariosTransportesHoTr_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbHotelesActividades> tbHotelesActividadesHoAc_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbHotelesActividades> tbHotelesActividadesHoAc_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbHoteles> tbHotelesHote_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbHoteles> tbHotelesHote_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbHotelesMenus> tbHotelesMenusHoMe_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbHotelesMenus> tbHotelesMenusHoMe_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbMenus> tbMenusMenu_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbMenus> tbMenusMenu_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbPaises> tbPaisesPais_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbPaises> tbPaisesPais_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbPaquetePredeterminadosActividadesHoteles> tbPaquetePredeterminadosActividadesHotelesPaAc_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbPaquetePredeterminadosActividadesHoteles> tbPaquetePredeterminadosActividadesHotelesPaAc_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbPaquetePredeterminadosDetalles> tbPaquetePredeterminadosDetallesPaDe_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbPaquetePredeterminadosDetalles> tbPaquetePredeterminadosDetallesPaDe_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbPaquetePredeterminados> tbPaquetePredeterminadosPaqu_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbPaquetePredeterminados> tbPaquetePredeterminadosPaqu_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbPaquetesHabitaciones> tbPaquetesHabitacionesPaHa_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbPaquetesHabitaciones> tbPaquetesHabitacionesPaHa_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbPartners> tbPartnersPart_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbPartners> tbPartnersPart_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbPermisos> tbPermisosPerm_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbPermisos> tbPermisosPerm_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbRegistrosPagos> tbRegistrosPagosRePa_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbRegistrosPagos> tbRegistrosPagosRePa_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbReservacionTransporte> tbReservacionTransporteReTr_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbReservacionTransporte> tbReservacionTransporteReTr_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbReservacionesActividadesExtras> tbReservacionesActividadesExtrasReAE_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbReservacionesActividadesExtras> tbReservacionesActividadesExtrasReAE_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbReservacionesActividadesHoteles> tbReservacionesActividadesHotelesReAH_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbReservacionesActividadesHoteles> tbReservacionesActividadesHotelesReAH_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbReservacionesDetalles> tbReservacionesDetallesReDe_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbReservacionesDetalles> tbReservacionesDetallesReDe_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbReservacionesHoteles> tbReservacionesHotelesReHo_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbReservacionesHoteles> tbReservacionesHotelesReHo_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbReservaciones> tbReservacionesResv_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbReservaciones> tbReservacionesResv_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbReservaciones> tbReservacionesUsua_ { get; set; }
        public virtual ICollection<tbRestaurantes> tbRestaurantesRest_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbRestaurantes> tbRestaurantesRest_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbRoles> tbRolesRole_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbRoles> tbRolesRole_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbTipoMenus> tbTipoMenusTime_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbTipoMenus> tbTipoMenusTime_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbTipoPartners> tbTipoPartnersTiPar_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbTipoPartners> tbTipoPartnersTiPar_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbTiposActividades> tbTiposActividadesTiAc_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbTiposActividades> tbTiposActividadesTiAc_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbTiposPagos> tbTiposPagosTiPa_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbTiposPagos> tbTiposPagosTiPa_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbTiposTransportes> tbTiposTransportesTiTr_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbTiposTransportes> tbTiposTransportesTiTr_UsuarioModificaNavigation { get; set; }
        public virtual ICollection<tbTransportes> tbTransportesTprt_UsuarioCreacionNavigation { get; set; }
        public virtual ICollection<tbTransportes> tbTransportesTprt_UsuarioModificaNavigation { get; set; }
    }
}