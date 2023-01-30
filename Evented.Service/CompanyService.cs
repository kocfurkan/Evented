using Evented.Domain.Contracts;
using Evented.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Service
{
    public class CompanyService : ICompanyService
    {
        
        private readonly IGenericRepository<Company> genRepo;
        public CompanyService(IGenericRepository<Company> _genRepo)
        {
            genRepo = _genRepo; 
        }

        public Task AddBulkCompanysAsync(List<Company> items)
        {
            
            return genRepo.AddBulkAsync(items);
        }

        public async Task<Company> AddCompanyAsync(Company item)
        {
            return await genRepo.AddAsync(item);
        }

        public Task DeleteCompanyAsync(int id)
        {
           return genRepo.DeleteAsync(id);
        }

        public async Task<List<Company>> GetAllCompanysAsync()
        {
            return await genRepo.GetAllAsync();
        }

        public Task<List<Event>> GetCompaniesByFieldOfWork(string fieldofwork)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetCompanyAsync(int? id)
        {
            return await genRepo.GetAsync(id);
        }

        public Task UpdateCompanyAsync(Company item)
        {
            return genRepo.UpdateAsync(item);
        }

        public Task<bool> CompanyExists(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Company>> ICompanyService.GetCompaniesByFieldOfWork(string fieldofwork)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetUserCompanies(string id)
        {
            List<Company> companies = await genRepo.GetAllAsync();

            IEnumerable<Company> userCompanies = companies.Where(x => x.OwnedById == id).ToList();

            return userCompanies;
        }
    }
}
