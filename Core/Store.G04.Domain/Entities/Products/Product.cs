﻿namespace Store.G04.Domain.Entities.Products
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; } // FK
        public ProductBrand Brand { get; set; }
        public int TypeId { get; set; } // FK
        public ProductType Type { get; set; }
    }
}