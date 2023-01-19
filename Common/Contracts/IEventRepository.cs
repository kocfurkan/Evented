﻿using Evented.Common.ViewModels;
using Evented.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Application.Contracts
{
    //Add Task Specific To Event 
    public interface IEventRepository : IGenericRepository<Event> 
    {
        Task<List<Event>> GetEventsByDate(DateTime StartDate, DateTime EndeDate);
        Task<List<Event>> GetUserEvents(Guid userId);

    }
}