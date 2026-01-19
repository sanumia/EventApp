using EventsApp.DataAccess.Interfaces;
using EventsApp.Domain.Entities;


namespace EventsApp.DataAccess.Repositories
{
    public class EventRepository: BaseRepository<Event>, IEventRepository
    {
        public EventRepository(DatabaseContext context) : base(context)
        {
        }
    }
    
}
