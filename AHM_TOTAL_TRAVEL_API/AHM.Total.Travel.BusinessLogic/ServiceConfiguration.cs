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

            //Sales
            services.AddScoped<PaquetePredeterminadosDetallesRepository>();
            services.AddScoped<TiposPagosRepository>();
            services.AddScoped<PaquetePredeterminadosRepository>();
            TotalTravelContext.BuildConnectionString(connectionString);
        }
        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<GeneralService>();
            services.AddScoped<SaleService>();
        }
    }
}
