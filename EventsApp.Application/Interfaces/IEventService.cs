using EventsApp.Application.Dtos.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> CreateEventAsync(CreateEventDto createEventDto, CancellationToken cancellationToken = default);
        Task<EventDto> UpdateEventAsync(Guid id, UpdateEventDto updateEventDto, CancellationToken cancellationToken = default);
        Task<EventDto> DeleteEventAsync(Guid id, CancellationToken cancellationToken = default);
        Task<EventDto> GetEventByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<EventDto>> GetAllEventsAsync(CancellationToken cancellationToken = default);
        
    }
}
