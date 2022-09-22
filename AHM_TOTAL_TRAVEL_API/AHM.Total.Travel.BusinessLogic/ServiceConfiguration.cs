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
            //General
            services.AddScoped<CiudadesRepository>();
            services.AddScoped<DireccionesRepository>();
            services.AddScoped<PaisesRepository>();
            services.AddScoped<PartnersRepository>();

            //Sales
            services.AddScoped<PaquetePredeterminadosDetallesRepository>();
            services.AddScoped<TiposPagosRepository>();
            services.AddScoped<PaquetePredeterminadosRepository>();
            TotalTravelContext.BuildConnectionString(connectionString);
            //Activities
            //Hotel
            //Transport
        }
        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<GeneralService>();
            services.AddScoped<SaleService>();
            services.AddScoped<HotelService>();
            services.AddScoped<AccessService>();
            services.AddScoped<ActivitiesService>();
            services.AddScoped<TransportService>();
        }
    }
}
