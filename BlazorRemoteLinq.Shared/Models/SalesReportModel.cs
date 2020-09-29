using System.Collections.Generic;

namespace BlazorRemoteLinq.Shared.Models
{
    public class SalesReportModel
    {
        public IEnumerable<ProductSalesReportModel> ProductSalesReports { get; set; }
        public decimal Total { get; set; }
    }
}
