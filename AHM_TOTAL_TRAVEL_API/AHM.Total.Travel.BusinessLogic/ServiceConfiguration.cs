using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.DataAccess;
using AHM.Total.Travel.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
           
            //Access
            services.AddScoped<UsuariosLoginsRepository>();
            services.AddScoped<UsuariosRepository>();
            services.AddScoped<PermisosRepository>();
            services.AddScoped<ModulosRepository>();
            services.AddScoped<RolesPermisosRepository>();
            services.AddScoped<RolesRepository>();
            services.AddScoped<ModulosRepository>();
            services.AddScoped<NavbarRepository>();
            //General
            services.AddScoped<CiudadesRepository>();
            services.AddScoped<ColoniasRepository>();
            services.AddScoped<DireccionesRepository>();
            services.AddScoped<PaisesRepository>();
            services.AddScoped<PartnersRepository>();
            services.AddScoped<TipoPartnersRepository>();
            services.AddScoped<UploaderImageRepository>();

            //Sales
            services.AddScoped<PaquetePredeterminadosDetallesRepository>();
            services.AddScoped<TiposPagosRepository>();
            services.AddScoped<PaquetePredeterminadosRepository>();
            services.AddScoped<RegistrosPagosRepository>();
            services.AddScoped<PaquetesHabitacionesRepository>();
            services.AddScoped<PaquetesPredeterminadosActividadesHotelesRepository>();

            //Activities
            services.AddScoped<ActividadesRepository>();
            services.AddScoped<ActividadesExtrasRepository>();
            services.AddScoped<TiposActividadesRepository>();
            //Hotel
            services.AddScoped<CategoriasHabitacionesRepository>();
            services.AddScoped<HabitacionesRepository>();
            services.AddScoped<HotelesRepository>();
            services.AddScoped<HotelesActividadesRepository>();
            services.AddScoped<HotelesMenusRepository>();
            //Transport
            services.AddScoped<DestinosTransportesRepository>();
            services.AddScoped<DetallesTransportesRepository>();
            services.AddScoped<HorariosTransportesRepository>();
            services.AddScoped<TiposTransportesRepository>();
            services.AddScoped<TransportesRepository>();
            //Restaurant
            services.AddScoped<MenusRepository>();
            services.AddScoped<RestaurantesRepository>();
            services.AddScoped<MenuTypesRepository>();
            //Reservations
            services.AddScoped<ReservacionesActividadesExtraRepository>();
            services.AddScoped<ReservacionesActividadesHotelesRepository>();
            services.AddScoped<ReservacionesDetallesRepository>();
            services.AddScoped<ReservacionesHotelesRepository>();
            services.AddScoped<ReservacionRestaurantesRepository>();
            services.AddScoped<ReservacionTransporteRepository>();
            services.AddScoped<ReservacionesRepository>();

            TotalTravelContext.BuildConnectionString(connectionString);
        }
        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<GeneralService>();
            services.AddScoped<SaleService>();
            services.AddScoped<HotelService>();
            services.AddScoped<AccessService>();
            services.AddScoped<ActivitiesService>();
            services.AddScoped<TransportService>();
            services.AddScoped<RestaurantService>();
            services.AddScoped<ReservationService>();
            services.AddScoped<EmailSenderService>();
            services.AddScoped<LoginService>();
            services.AddScoped<ImagesService>();
        }
    }
}
