using ProjectFramework.Domain;
using ShopManagement.Application.Contracts.Company;

namespace ShopManagement.Domain.CompanyAgg
{
    public interface ICompanyRepository : IRepository<long, Company>
    {
        EditCompany GetDetails(long id);
        List<CompanyViewModel> GetCompanies();
        List<CompanyViewModel> Search(CompanySearcModel searchModel);
    }
}
