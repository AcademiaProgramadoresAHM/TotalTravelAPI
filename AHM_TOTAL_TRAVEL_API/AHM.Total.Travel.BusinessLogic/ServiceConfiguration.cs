using AHM.Total.Travel.DataAccess;
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
            TotalTravelContext.BuildConnectionString(connectionString);
        }
        public static void BusinessLogic(this IServiceCollection services)
        {

        }
    }
}
