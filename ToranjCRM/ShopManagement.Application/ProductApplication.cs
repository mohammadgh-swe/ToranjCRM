using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Inventory;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application;

public class ProductApplication : IProductApplication
{
    private readonly IInventoryApplication _inventoryApplication;
    private readonly IProductRepository _productRepository;

    public ProductApplication(IProductRepository productRepository, IInventoryApplication inventoryApplication)
    {
        _productRepository = productRepository;
        _inventoryApplication = inventoryApplication;
    }


    public OperationResult Create(CreateProduct command)
    {
        var operation = new OperationResult();
        if (_productRepository.Exists(p => p.Name == command.Name && p.CompanyId == command.CompanyId))
            return operation.Failed(ApplicationMessage.DuplicatedRecord);

        var slug = command.Slug.Slugify();

        var product = new Product(command.Name, command.Code, command.ShortDescription,
            command.Description, command.Size, command.UnitPrice ,command.Picture, slug, command.CategoryId, command.CompanyId);
        _productRepository.Create(product);
        _productRepository.SaveChanges();
        //Create inventory of product
        var inventory = new CreateInventory
        {
            ProductId = product.Id,
            CreationDate = product.CreateAt

        };
        _inventoryApplication.Create(inventory);


        return operation.Succeed();
    }

    public OperationResult Edit(EditProduct command)
    {
        var operation = new OperationResult();
        var product = _productRepository.Get(command.Id);
        if (product == null)
            return operation.Failed(ApplicationMessage.RecordNotFound);
        if (_productRepository.Exists(p => p.Name == command.Name && p.Id != command.Id))
            return operation.Failed(ApplicationMessage.DuplicatedRecord);

        var slug = command.Slug.Slugify();

        product.Edit(command.Name, command.Code, command.ShortDescription,
            command.Description, command.Size, command.UnitPrice, command.Picture, slug, command.CategoryId, command.CompanyId);
        _productRepository.SaveChanges();
        return operation.Succeed();
    }

    public EditProduct GetDetails(long id)
    {
        return _productRepository.GetDetails(id);
    }

    public List<ProductViewModel> Search(ProductSearchModel searchModel)
    {
        return _productRepository.Search(searchModel);
    }
}