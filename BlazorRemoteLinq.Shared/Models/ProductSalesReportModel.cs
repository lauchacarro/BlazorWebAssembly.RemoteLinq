namespace BlazorRemoteLinq.Shared.Models
{
    public class ProductSalesReportModel
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
