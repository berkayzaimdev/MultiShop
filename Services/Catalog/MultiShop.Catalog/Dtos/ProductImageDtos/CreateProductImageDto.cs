﻿using MultiShop.Catalog.Dtos.ProductImageDtos.Common;

namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public class CreateProductImageDto : ProductImageDto
    {
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string ProductId { get; set; }
    }
}
