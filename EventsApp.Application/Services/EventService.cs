using EventsApp.Application.Dtos.Event;
using EventsApp.Application.Interfaces;
using EventsApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Application.Services
{
    internal class EventService:IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventDto> CreateEventAsync(CreateEventDto createEventDto, CancellationToken cancellationToken)
        {

        }
    }
}
