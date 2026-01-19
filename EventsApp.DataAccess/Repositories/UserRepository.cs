using EventsApp.DataAccess.Interfaces;
using EventsApp.Domain.Entities;


namespace EventsApp.DataAccess.Repositories
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context):base(context)
        {
            
        }
    }
}
