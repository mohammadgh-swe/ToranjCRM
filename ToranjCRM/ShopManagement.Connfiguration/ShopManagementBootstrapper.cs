using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.Customer;
using ShopManagement.Application.Contracts.Inventory;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.CompanyAgg;
using ShopManagement.Domain.CustomerAgg;
using ShopManagement.Domain.InventoryAgg;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();

            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICompanyApplication, CompanyApplication>();

            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();

            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerApplication, CustomerApplication>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderApplication, OrderApplication>();

            services.AddDbContext<ShopContext>(option => option.UseSqlServer(connectionString));
        }
    }
}
