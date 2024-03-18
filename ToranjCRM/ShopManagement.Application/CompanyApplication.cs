using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Domain.CompanyAgg;

namespace ShopManagement.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyApplication(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public OperationResult Create(CreateCompany command)
        {
            var operation = new OperationResult();
            if (_companyRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var company = new Company(command.Name, command.Address, command.AgentName,
                command.AgentPhoneNubmber, command.PhoneNumber, command.Description, slug);

            _companyRepository.Create(company);
            _companyRepository.SaveChanges();
            return operation.Succeed();
        }

        public OperationResult Edit(EditCompany command)
        {

            var operation = new OperationResult();
            var company = _companyRepository.Get(command.Id);
            if (company == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_companyRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            company.Edit(command.Name, command.Address, command.AgentName,
                command.AgentPhoneNubmber, command.PhoneNumber, command.Description, slug);
            _companyRepository.SaveChanges();
            return operation.Succeed();
        }

        public OperationResult Delete(long id)
        {
            var opration = new OperationResult();
            var company = _companyRepository.Get(id);
            if (company == null)
                return opration.Failed(ApplicationMessage.RecordNotFound);

            company.Delete();
            _companyRepository.SaveChanges();
            return opration.Succeed();
        }

        public OperationResult Restore(long id)
        {

            var opration = new OperationResult();
            var company = _companyRepository.Get(id);
            if (company == null)
                return opration.Failed(ApplicationMessage.RecordNotFound);

            company.Restore();
            _companyRepository.SaveChanges();
            return opration.Succeed();
        }

        public EditCompany GetDetails(long id)
        {
            return _companyRepository.GetDetails(id);
        }

        public List<CompanyViewModel> GetCompanies()
        {
            return _companyRepository.GetCompanies();
        }

        public List<CompanyViewModel> Search(CompanySearcModel searchModel)
        {
            return _companyRepository.Search(searchModel);
        }
    }
}
