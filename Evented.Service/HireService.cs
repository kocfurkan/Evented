using Evented.DAL.Data;
using Evented.DAL.Repositories;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Service
{
    public class HireService : IHireService
    {
        private readonly IGenericRepository<Event> evRepo;
        private readonly ApplicationDbContext db;
        private readonly EventRepository eventRepository;
        public HireService(IGenericRepository<Event> _evRepo, EventRepository _eventRepository, ApplicationDbContext _db)
        {
            db = _db;
            evRepo = _evRepo;
            eventRepository = _eventRepository;
        }
        public async Task HireNotification(int id, int currentEventId, string userId)
        {
            Event myevent = await evRepo.GetAsync(currentEventId);
            Notification notification = new Notification();
            notification.EventId = currentEventId;
            notification.CompanyId = id;
            notification.UserId = userId;
            notification.Description = "You are Invited to Orgnize the event" + myevent.Title;
            notification.Title = "Event Organization";

            await db.AddAsync(notification);
            db.SaveChanges();

        }
        public async Task<List<Notification>> GetNotifications(string id)
        {
            return await db.Set<Notification>().Where(x=>x.Company.OwnedById == id).ToListAsync();
        }

        public async Task Hire(int id, int currentEventId)
        {
            //GET NOTIF AND SET IS ACCEPTED TO OK
            Event myevent = await evRepo.GetAsync(currentEventId);
          

            myevent.HiredCompanyId = id;
            

            await evRepo.UpdateAsync(myevent);
        }

        public async Task HireReject(int id)
        {
           Notification notif = await db.Set<Notification>().FindAsync(id);
            db.Set<Notification>().Remove(notif);
            db.SaveChanges();
        }

     
        //public async Task Hire(int id, int currentEventId)
        //{
        //    Event myevent = await evRepo.GetAsync(currentEventId);
        //    Company company = await companyService.GetCompanyAsync(id);

        //    myevent.HiredCompany = company;
        //    myevent.HiredCompanyId = company.Id;
        //    company.Events.Add(myevent);

        //    await companyService.UpdateCompanyAsync(company);
        //    await evRepo.UpdateAsync(myevent);
        //}
    }
}
