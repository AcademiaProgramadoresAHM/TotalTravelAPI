using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Common.SecurityModels;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<RefreshToken, VW_tbUsuariosLogins>().ReverseMap();
            CreateMap<UserLoggedModel, VW_tbUsuarios>().ReverseMap();
            CreateMap<CiudadesViewModel, tbCiudades>().ReverseMap();
            CreateMap<ActividadesExtrasViewModel, tbActividadesExtras>().ReverseMap();
            CreateMap<ActividadesViewModel, tbActividades>().ReverseMap();
            CreateMap<CategoriasHabitacionesViewModel, tbCategoriasHabitaciones>().ReverseMap();
            CreateMap<DetallesTransportesViewModel, tbDetallesTransportes>().ReverseMap();
            CreateMap<DestinosTransporteViewModel, tbDestinosTransportes>().ReverseMap();
            CreateMap<DireccionesViewModel, tbDirecciones>().ReverseMap();
            CreateMap<HabitacionesViewModel, tbHabitaciones>().ReverseMap();
            CreateMap<HorariosTransportesViewModel, tbHorariosTransportes>().ReverseMap();
            CreateMap<HotelesActividadesViewModel, tbHotelesActividades>().ReverseMap();
            CreateMap<HotelesMenusViewModel, tbHotelesMenus>().ReverseMap();
            CreateMap<HotelesViewModel, tbHoteles>().ReverseMap();
            CreateMap<PaisesViewModel, tbPaises>().ReverseMap();
            CreateMap<PaquetePredeterminadosDetallesViewModel, tbPaquetePredeterminadosDetalles>().ReverseMap();
            CreateMap<PaquetePredeterminadosViewModel, tbPaquetePredeterminados>().ReverseMap();
            CreateMap<PaquetesHabitacionesViewModel, tbPaquetesHabitaciones>().ReverseMap();
            CreateMap<PartnersViewModel, tbPartners>().ReverseMap();
            CreateMap<PermisosViewModel, tbPermisos>().ReverseMap();
            CreateMap<RegistrosPagosViewModel, tbRegistrosPagos>().ReverseMap();
            CreateMap<ReservacionesActividadesExtrasViewModel, tbReservacionesActividadesExtras>().ReverseMap();
            CreateMap<ReservacionesActividadesHotelesViewModel, tbReservacionesActividadesHoteles>().ReverseMap();
            CreateMap<ReservacionesHotelesViewModel, tbReservacionesHoteles>().ReverseMap();
            CreateMap<ReservacionesDetallesViewModel, tbReservacionesDetalles>().ReverseMap();
            CreateMap<ReservacionesDetallesViewModel, tbReservacionesDetalles>().ReverseMap();
            CreateMap<ReservacionesViewModel, tbReservaciones>().ReverseMap();
            CreateMap<ReservacionesDetallesViewModel, tbReservacionesDetalles>().ReverseMap();
            CreateMap<ReservacionRestaurantesViewModel, tbReservacionRestaurantes>().ReverseMap();
            CreateMap<ReservacionTransporteViewModel, tbReservacionTransporte>().ReverseMap();
            CreateMap<ReservacionTransporteViewModel, tbReservacionTransporte>().ReverseMap();
            CreateMap<RolesPermisosViewModel, tbRolesPermisos>().ReverseMap();
            CreateMap<RolesViewModel, tbRoles>().ReverseMap();
            CreateMap<MenusViewModel, tbMenus>().ReverseMap();
            CreateMap<RestaurantesViewModel, tbRestaurantes>().ReverseMap();
            CreateMap<TipoMenusViewModel, tbTipoMenus>().ReverseMap();
            CreateMap<TiposActividadesViewModel, tbTiposActividades>().ReverseMap();
            CreateMap<TiposPagosViewModel, tbTiposPagos>().ReverseMap();
            CreateMap<TiposTransportesViewModel, tbTiposTransportes>().ReverseMap();
            CreateMap<TransportesViewModel, tbTransportes>().ReverseMap();
            CreateMap<UsuariosViewModel, tbUsuarios>().ReverseMap();

        }
    }
}
