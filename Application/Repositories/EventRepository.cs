using Evented.Application.Contracts;
using Evented.Common.ViewModels;
using Evented.Data.Models;
using Evented.Web.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async List<Event> GetAllEvents()
        {
            return GetAllAsync();
        }

    }
}
