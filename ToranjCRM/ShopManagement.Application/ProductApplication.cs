using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application;

public class ProductApplication : IProductApplication
{

    private readonly IProductRepository _productRepository;

    public ProductApplication(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public OperationResult Create(CreateProduct command)
    {
        var operation = new OperationResult();
        if (_productRepository.Exists(p => p.Name == command.Name))
            return operation.Failed(ApplicationMessage.DuplicatedRecord);

        var slug = command.Slug.Slugify();

        var product = new Product(command.Name, command.Code, command.ShortDescription,
            command.Description, command.Size, command.Picture, command.UnitPrice,
            command.ProductCount, slug, command.CategoryId);
        _productRepository.Create(product);
        _productRepository.SaveChanges();
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
            command.Description, command.Size, command.Picture, command.UnitPrice,
            command.ProductCount, slug, command.CategoryId);
        _productRepository.SaveChanges();
        return operation.Succeed();
    }

    public OperationResult InStock(long id)
    {
        var operation = new OperationResult();
        var product = _productRepository.Get(id);
        if (product == null)
            return operation.Failed(ApplicationMessage.RecordNotFound);
            
        product.InStock();
        _productRepository.SaveChanges();
        return operation.Succeed();
    }

    public OperationResult NotInStock(long id)
    {
        var operation = new OperationResult();
        var product = _productRepository.Get(id);
        if (product == null)
            return operation.Failed(ApplicationMessage.RecordNotFound);

        product.NotInStock();
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