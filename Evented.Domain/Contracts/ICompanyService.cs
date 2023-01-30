using Evented.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Domain.Contracts
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyAsync(int? id);
        Task<List<Company>> GetAllCompanysAsync();
        Task<Company> AddCompanyAsync(Company item);
        Task AddBulkCompanysAsync(List<Company> items);
        Task<bool> CompanyExists(int id);
        Task DeleteCompanyAsync(int id);
        Task UpdateCompanyAsync(Company item);
        Task<List<Company>> GetCompaniesByFieldOfWork(string fieldofwork);
        Task<IEnumerable<Company>> GetUserCompanies(string id);
    }
}
