using Evented.Domain.Contracts;
using Evented.Domain.Repositories;
using Evented.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Evented.DAL.Repositories;

namespace Evented.Service
{
    public class EventService : IEventService

    {
        private readonly IGenericRepository<Event> genRepo;
        private readonly EventRepository eventRepository;
        public EventService(IGenericRepository<Event> _genRepo, EventRepository _eventRepository)
        {
            genRepo = _genRepo;
            eventRepository = _eventRepository;
        }

        public Task AddBulkEventsAsync(List<Event> items)
        {
            return genRepo.AddBulkAsync(items);
        }

        public Task<Event> AddEventAsync(Event item)
        {
            item.UpdatedAt = DateTime.Now;
            item.CreatedAt = DateTime.Now;
            return genRepo.AddAsync(item);
        }

        public Task DeleteEventAsync(int id)
        {
            return genRepo.DeleteAsync(id);
        }

        public async Task<bool> EventExists(int id)
        {
            return await genRepo.Exists(id);
        }

        public Task<List<Event>> GetEventsConditiona()
        {
            return genRepo.GetAllAsync();
        }

        public Task<Event> GetEventAsync(int? id)
        {
            return genRepo.GetAsync(id);
        }

        public Task UpdateEventAsync(Event item)
        {

            return genRepo.UpdateAsync(item);
        }

        public async Task<List<Event>> GetEventsByDate(DateTime StartDate, DateTime EndeDate)
        {
            List<Event> events = await genRepo.GetAllAsync();
            List<Event> eventsfiltered = new();
            foreach (var item in events)
            {
                if (item.BeginsAt >= StartDate && item.EndsAt <= EndeDate)
                {
                    eventsfiltered.Add(item);
                }
            }
            return eventsfiltered;
        }

        public async Task<List<Event>> GetUserEvents(string userId)
        {
            List<Event> events = await genRepo.GetAllAsync();
            List<Event> userEvents = new();
            foreach (var item in events)
            {
                if (item.CreatorId == userId.ToString())
                {
                    userEvents.Add(item);
                }
            }
            return userEvents;
        }
        public Event GetEventsConditional(Event events)
        {
            return eventRepository.GetEventsConditional(events);
        }

        public  List<Event> GetEventsConditional()
        {
            return  eventRepository.GetEventsConditional();
        }



        //public async Task<User> FindBasedTwoCond(Expression<Func<Event, User>> expression)
        //{
        //    return await genRepo.FindBasedTwoCond(expression);
        //}



        //public Task<Event> FindBasedTwoCond(Expression<Func<User, List<Event>>> condition, Expression<Func<Event, bool>> condition2)
        //{
        //    return genRepo.GetUserJoined(condition, condition2);
        //}

        //public async Task<Event> GetForDelete(int? id)
        //{
        //    Event events = await genRepo.GetAsync(id);


        //}
    }
}
