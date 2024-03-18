using ProjectFramework.Infrastructure;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Domain.CompanyAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CompanyRepository : RepositoryBase<long, Company>, ICompanyRepository
    {
        private readonly ShopContext _context;

        public CompanyRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditCompany GetDetails(long id)
        {
            return _context.Companies.Select(x => new EditCompany
            {
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                AgentName = x.AgentName,
                AgentPhoneNubmber = x.AgentPhoneNubmber,
                Description = x.Description,
                Slug = x.Slug

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CompanyViewModel> GetCompanies()
        {
            return _context.Companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<CompanyViewModel> Search(CompanySearcModel searchModel)
        {
            var query = _context.Companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PhoneNumber = x.PhoneNumber,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.PhoneNumber))
                query = query.Where(x => x.PhoneNumber.Contains(searchModel.PhoneNumber));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
