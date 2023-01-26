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
            throw new NotImplementedException();
        }

        public Task<Company> AddCompanyAsync(Company item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CompanyExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompanyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllCompanysAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetCompaniesByFieldOfWork(string fieldofwork)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompanyAsync(Company item)
        {
            throw new NotImplementedException();
        }
    }
}
