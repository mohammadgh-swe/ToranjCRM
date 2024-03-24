using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;
        public SelectList Companies;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly ICompanyApplication _companyApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication, ICompanyApplication companyApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
            _companyApplication = companyApplication;
        }


        public void OnGet(ProductSearchModel searchModel)
        {
            Companies = new SelectList(_companyApplication.GetCompanies(), "Id", "Name");
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct()
            {
                Categories = _productCategoryApplication.GetProductCategories(),
                Companies = _companyApplication.GetCompanies(),
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
            product.Categories = _productCategoryApplication.GetProductCategories();
            product.Companies = _companyApplication.GetCompanies();

            return Partial("./Edit", product);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
