using AutoMapper;
using EventsApp.Application.Dtos.Event;
using EventsApp.Application.Dtos.Image;
using EventsApp.Application.Interfaces;
using EventsApp.DataAccess.Interfaces;
using EventsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public EventService(IEventRepository eventRepository, IMapper mapper, IImageService imageService)
        {
            _eventRepository = eventRepository;
            _imageService = imageService;
            _mapper = mapper;
        }
        public async Task<EventDto> CreateEventAsync(CreateEventDto createEventDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Event>(createEventDto);// dto to entity
            entity.Id = Guid.NewGuid();

            if (createEventDto.Image != null && createEventDto.Image.Length > 0)
            {
                var uploadImageDto = new UploadImageDto
                {
                    File = createEventDto.Image,
                    Description = $"Add image for {createEventDto.Name}"
                };
                var imageDto = await _imageService.UploadImageAsync(uploadImageDto, cancellationToken);
                entity.ImageId = imageDto.Id;

            }
            var createdEvent = await _eventRepository.CreateAsync(entity, cancellationToken);
            return _mapper.Map<EventDto>(createdEvent);//return mapped dto from entity
        }

        public async Task<EventDto> UpdateEventAsync(Guid id, UpdateEventDto updateEventDto, CancellationToken cancellationToken)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(id, cancellationToken);
            if (existingEvent == null)
            {
                throw new KeyNotFoundException($"Event with {id} not found");
            }

            if (updateEventDto.Image != null && updateEventDto.Image.Length > 0)
            {
                if (existingEvent.ImageId.HasValue)
                {
                    var updateImageDto = new UpdateImageDto
                    {
                        File = updateEventDto.Image,
                        Description = $"Update image for {existingEvent.Name}"
                    };
                    await _imageService.UpdateImageAsync(existingEvent.ImageId.Value, updateImageDto, cancellationToken);
                }
                else
                {
                    var uploadImageDto = new UploadImageDto
                    {
                        File = updateEventDto.Image,
                        Description = $"Add image for {existingEvent.Name}"
                    };
                    var imageDto = await _imageService.UploadImageAsync(uploadImageDto, cancellationToken);
                    existingEvent.ImageId = imageDto.Id;
                }
            }

            _mapper.Map(updateEventDto, existingEvent);

            var updatedEvent = await _eventRepository.UpdateAsync(existingEvent, cancellationToken);
            return _mapper.Map<EventDto>(updatedEvent);

        }

        public async Task<EventDto> DeleteEventAsync(Guid id, CancellationToken cancellationToken)
        {
            var deletedEvent = await _eventRepository.GetByIdAsync(id, cancellationToken);
            if (deletedEvent == null)
            {
                throw new KeyNotFoundException($"Event with {id} not found");
            }

            if (deletedEvent.ImageId.HasValue)
            {
                await _imageService.DeleteImageAsync(deletedEvent.ImageId.Value, cancellationToken);
            }
            deletedEvent = await _eventRepository.DeleteAsync(id, cancellationToken);
            return _mapper.Map<EventDto>(deletedEvent);
        }

        public async Task<EventDto> GetEventByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var eventDto = await _eventRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<EventDto>(eventDto);
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync(CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }
    }
}
