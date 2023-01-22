
using Evented.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Domain.Contracts
{
    //Add Task Specific To Event 
    public interface IEventService 
    {
        Task<Event> GetEventAsync(int? id);
        Task<List<Event>> GetAllEventsAsync();
        Task<Event> AddEventAsync(Event item);
        Task AddBulkEventsAsync(List<Event> items);
        Task<bool> EventExists(int id);
        Task DeleteEventAsync(int id);
        Task UpdateEventAsync(Event item);
        Task<List<Event>> GetEventsByDate(DateTime StartDate, DateTime EndeDate);
        Task<List<Event>> GetUserEvents(string userId);
        
    }
}
