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
            services.AddScoped<UsuariosRepository>();
            services.AddScoped<PermisosRepository>();
            services.AddScoped<RolesPermisosRepository>();
            services.AddScoped<RolesRepository>();
            //General
            services.AddScoped<CiudadesRepository>();
            services.AddScoped<DireccionesRepository>();
            services.AddScoped<PaisesRepository>();
            services.AddScoped<PartnersRepository>();
            //Sales
            services.AddScoped<PaquetePredeterminadosDetallesRepository>();
            services.AddScoped<TiposPagosRepository>();
            services.AddScoped<PaquetePredeterminadosRepository>();
            
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
            services.AddScoped<TiposMenuRepository>();
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
        }
    }
}
