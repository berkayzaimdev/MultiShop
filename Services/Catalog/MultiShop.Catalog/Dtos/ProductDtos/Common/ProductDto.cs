﻿namespace MultiShop.Catalog.Dtos.ProductDtos.Common
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public string CategoryId { get; set; }
    }
}
