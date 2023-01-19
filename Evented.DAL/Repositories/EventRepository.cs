using Evented.Application.Contracts;
using Evented.Domain.Models;
using Evented.Web.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Evented.Application.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public EventRepository(ApplicationDbContext db, UserManager<User> userManager) : base(db)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<List<Event>> GetEventsByDate(DateTime StartDate, DateTime EndeDate)
        {
            List<Event> events =  await GetAllAsync();
            List<Event> eventsfiltered = new();
            foreach (var item in events)
            {
             if(item.BeginsAt >= StartDate && item.EndsAt<= EndeDate)
                {
                    eventsfiltered.Add(item);
                }
            }
            return eventsfiltered;
        }
        public async Task<List<Event>> GetUserEvents(Guid userId)
        {
          
            List<Event> events = await GetAllAsync();
            List<Event> userEvents = new();
            foreach (var item in events)
            {
                if(item.CreatorUser.Id == userId.ToString())
                {
                    userEvents.Add(item);
                }
            }
            return userEvents;
        }
    }
}
