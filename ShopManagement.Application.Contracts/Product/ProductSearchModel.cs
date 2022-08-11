namespace ShopManagement.Application.Contracts.Product
{
    public class ProductSearchModel
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public long ProductCategoryId { get; set; }
    }
}
