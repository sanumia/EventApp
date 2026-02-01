using EventsApp.DataAccess.Interfaces;
using EventsApp.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.DataAccess
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEventRepository, EventRepository>();
            serviceCollection.AddScoped<IImageRepository, ImageRepository>();
            return serviceCollection;
        }
    }
}
