using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.Inventory;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public InventorySearchModel SearchModel;
        public List<InventoryViewModel> Inventory;
        public SelectList ProductCategories;
        public SelectList Companies;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly ICompanyApplication _companyApplication;
        private readonly IInventoryApplication _inventoryApplication; 

        public IndexModel(IProductApplication ProductApplication, IInventoryApplication inventoryApplication,
            IProductCategoryApplication productCategoryApplication, ICompanyApplication companyApplication)
        {
            _productApplication = ProductApplication;
            _inventoryApplication = inventoryApplication ;
            _productCategoryApplication = productCategoryApplication;
            _companyApplication = companyApplication;
        }

        public void OnGet(InventorySearchModel searchModel)
        {
            Companies = new SelectList(_companyApplication.GetCompanies(), "Id", "Name");
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Inventory = _inventoryApplication.Search(searchModel);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InventoryId = id
            };
            return Partial("Increase", command);
        }

        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDecrease(long id)
        {
            var command = new DecreaseInventory()
            {
               InventoryId = id
            };
            return Partial("Decrease", command);
        }

        public JsonResult OnPostDecrease(DecreaseInventory command)
        {
            var result = _inventoryApplication.Decrease(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            var log = _inventoryApplication.GetOperationLog(id);
            return Partial("OperationLog", log);
        }

    }
}
