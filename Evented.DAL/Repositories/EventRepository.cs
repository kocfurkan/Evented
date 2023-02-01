using Evented.DAL.Data;
using Evented.Domain.Models;
using Evented.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Evented.DAL.Repositories
{
    public class EventRepository
    {
        private readonly ApplicationDbContext _db;
        public EventRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Event GetEventsConditional(Event myEvent)
        {
            return _db.Set<Event>().Include(x => x.UsersJoined).FirstOrDefault(x=>x.Id == myEvent.Id);
        }
   
        public List<Event> GetEventsConditional()
        {
            return _db.Set<Event>().Include(x => x.CreatorUser).Include(x => x.HiredCompany).ToList();
        }
    }
}
