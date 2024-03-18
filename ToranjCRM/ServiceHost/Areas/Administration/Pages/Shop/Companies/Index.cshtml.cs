using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Companies
{
    public class IndexModel : PageModel
    {
        public CompanySearcModel SearchModel;
        public List<CompanyViewModel> Companies;

        private readonly ICompanyApplication _companyApplication;

        public IndexModel(ICompanyApplication companyApplication)
        {
            _companyApplication = companyApplication;
        }


        public void OnGet(CompanySearcModel searchModel)
        {
            Companies = _companyApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateCompany());
        }

        public JsonResult OnPostCreate(CreateCompany command)
        {
            var result = _companyApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _companyApplication.GetDetails(id);
            return Partial("./Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditCompany command)
        {
            var result = _companyApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
