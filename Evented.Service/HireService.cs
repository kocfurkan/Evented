using Evented.DAL.Repositories;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Service
{
    public class HireService:IHireService
    {
        private readonly IGenericRepository<Event> evRepo;
        private readonly ICompanyService companyService;
        private readonly EventRepository eventRepository;
        public HireService(IGenericRepository<Event> _evRepo, EventRepository _eventRepository, ICompanyService _companyService)
        {
            evRepo = _evRepo;
            companyService = _companyService;
            eventRepository = _eventRepository;
        }
        public async Task Hire(int id, int currentEventId)
        {
            Event myevent = await evRepo.GetAsync(currentEventId);
            Company company = await companyService.GetCompanyAsync(id);

            myevent.HiredCompany = company;
            myevent.HiredCompanyId= company.Id;
            company.Events.Add(myevent);

            await companyService.UpdateCompanyAsync(company);
            await evRepo.UpdateAsync(myevent);
        }
    }
}
