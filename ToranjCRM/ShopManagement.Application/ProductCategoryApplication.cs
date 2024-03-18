﻿using ProjectFramework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }


        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var productCategory = new ProductCategory(command.Name, command.Description,
                command.Picture, slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Succeed();
        }


        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                operation.Failed(ApplicationMessage.RecordNotFound);

            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                operation.Failed(ApplicationMessage.DuplicatedRecord);


            var slug = command.Slug.Slugify();

            productCategory.Edit(command.Name, command.Description,
                command.Picture, slug);
            
            _productCategoryRepository.SaveChanges();

            return operation.Succeed();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(id);
            if (productCategory == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productCategory.Restore();
            _productCategoryRepository.SaveChanges();
            return operation.Succeed();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(id);
            if (productCategory == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productCategory.Delete();
            _productCategoryRepository.SaveChanges();
            return operation.Succeed();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }
    }
}
