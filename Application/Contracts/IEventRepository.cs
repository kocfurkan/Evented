using Evented.Common.ViewModels;
using Evented.Data.Models;
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
        
    }
}
