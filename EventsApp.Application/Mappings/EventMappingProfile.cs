using EventsApp.Application.Dtos.Event;
using EventsApp.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Application.Mappings
{
    public class EventMappingProfile:Profile
    {
        public EventMappingProfile()
        {
            // Entitie to DTO
            CreateMap<Event, EventDto>();

            // DTO to Entitie
            CreateMap<CreateEventDto, Event>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.Ignore()) 
                .ForMember(dest => dest.ImageId, opt => opt.Ignore()); 

            CreateMap<UpdateEventDto, Event>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.Ignore()) 
                .ForMember(dest => dest.ImageId, opt => opt.Ignore()); 
        }
    }
}
