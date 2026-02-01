using EventsApp.DataAccess.Interfaces;
using EventsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.DataAccess.Repositories
{
    public class ImageRepository:BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
