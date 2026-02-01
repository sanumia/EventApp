using Microsoft.AspNetCore.Mvc;
using EventsApp.Application.Interfaces;
using EventsApp.Application.Dtos.Event;

namespace EventsApp.API.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IImageService _imageService;
        public EventsController(IEventService eventService, IImageService imageService)
        {
            _eventService = eventService;
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent([FromForm] CreateEventDto createEventDto, CancellationToken cancellationToken)
        {
            try
            {

                var result = await _eventService.CreateEventAsync(createEventDto, cancellationToken);
                return CreatedAtAction(nameof(GetByIdEvent), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EventDto>> GetByIdEvent([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            try
            {

                var result = await _eventService.GetEventByIdAsync(id, cancellationToken);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAllEvent(CancellationToken cancellationToken)
        {
            var events = await _eventService.GetAllEventsAsync(cancellationToken);
            return Ok(events);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EventDto>> DeleteEvent([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            try
            {

                var deletedEvent = await _eventService.DeleteEventAsync(id, cancellationToken);
                return Ok(deletedEvent);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EventDto>> UpdateEvent([FromRoute] Guid id, [FromBody] UpdateEventDto updateEventDto, CancellationToken cancellationToken)
        {
            try
            {
                var updatedEvent = _eventService.UpdateEventAsync(id, updateEventDto, cancellationToken);
                return Ok(updatedEvent);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}/image")]
        public async Task<ActionResult> GetEventImage([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            try
            {

                var eventDto = await _eventService.GetEventByIdAsync(id, cancellationToken);
                if (eventDto.Image == null)
                {
                    return NotFound("Image not found");
                }
                var imageBytes = await _imageService.GetImageBytesAsync(eventDto.ImageId.Value, cancellationToken);
                var image = await _imageService.GetImageByIdAsync(eventDto.ImageId.Value, cancellationToken);
                return File(imageBytes, image.ContentType, image.FileName);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
