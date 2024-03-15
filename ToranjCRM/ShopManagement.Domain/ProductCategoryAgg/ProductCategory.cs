﻿using ProjectFramework.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string Slug { get; private set; }    

        public ProductCategory(string name, string description, string picture, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            Slug = slug;
        }

        public void Edit(string name, string description, string picture, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            Slug = slug;

            UpdateAt = DateTime.Now;
            UpdatedBy = " ";
        }

    }
}