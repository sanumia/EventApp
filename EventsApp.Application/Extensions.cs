using EventsApp.Application.Interfaces;
using EventsApp.Application.Mappings;
using EventsApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddBussinessLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(cfg => { },
    typeof(EventMappingProfile).Assembly);
            serviceCollection.AddScoped<IEventService, EventService>();
            serviceCollection.AddScoped<IImageService, ImageService>();

            return serviceCollection;
        }
    }
}
