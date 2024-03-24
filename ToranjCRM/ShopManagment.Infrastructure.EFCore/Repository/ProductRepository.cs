using Microsoft.EntityFrameworkCore;
using ProjectFramework.Application;
using ProjectFramework.Infrastructure;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }


        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                Code = x.Code,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                Size = x.Size,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
                CompanyId = x.CompanyId

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                NameCompanyCode = x.Name + " - " + x.Company.Name + " - " + x.Code,
            }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.Include(x => x.Category).Select(x => new ProductViewModel
            {

                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                Code = x.Code,
                Size = x.Size,
                CreationDate = x.CreateAt.ToFarsi(),
                UpdateAt = x.UpdateAt.ToFarsi(),
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Company = x.Company.Name,
                CompanyId = x.CompanyId
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            if (searchModel.CompanyId != 0)
                query = query.Where(x => x.CompanyId == searchModel.CompanyId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
