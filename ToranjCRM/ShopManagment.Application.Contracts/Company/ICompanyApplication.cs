using ProjectFramework.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.Company
{
    public interface ICompanyApplication
    {
        OperationResult Create(CreateCompany command);
        OperationResult Edit(EditCompany command);
        OperationResult Delete(long id);
        OperationResult Restore(long id);
        EditCompany GetDetails(long id);
        List<CompanyViewModel> GetCompanies();
        List<CompanyViewModel> Search(CompanySearcModel searchModel);

    }
}
