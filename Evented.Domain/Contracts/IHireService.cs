using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Domain.Contracts
{
    public interface IHireService
    {
       Task Hire(int id, int currentEventId);
    }
}
