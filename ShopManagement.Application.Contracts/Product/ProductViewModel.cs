﻿namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public bool IsInStock { get; set; }//mojoodi anbar
        public long ProductCategoryId { get; set; }
        public double UnitPrice { get; set; }
    }
}
