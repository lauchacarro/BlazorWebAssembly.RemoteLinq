using System.Linq;
using System.Threading.Tasks;

using BlazorRemoteLinq.Shared.Models;
using BlazorRemoteLinq.Web.Repository;

using Remote.Linq;

namespace BlazorRemoteLinq.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRemoteRepository _remoteRepository;

        public OrderService(IRemoteRepository remoteRepository)
        {
            _remoteRepository = remoteRepository;
        }

        public async Task<SalesReportModel> GetSalesReport()
        {
            var productSalesReport = await (from p in _remoteRepository.Products.Include(x => x.ProductCategory)
                                            join o in _remoteRepository.OrderItems on p.Id equals o.ProductId
                                            where o.Quantity > 0
                                            orderby p.Id
                                            select new ProductSalesReportModel
                                            {
                                                ProductName = p.Name,
                                                CategoryName = p.ProductCategory.Name,
                                                Quantity = o.Quantity,
                                                UnitPrice = p.Price,
                                                Total = p.Price * o.Quantity
                                            }).ToListAsync();

            return new SalesReportModel
            {
                ProductSalesReports = productSalesReport,
                Total = productSalesReport.Sum(x => x.Total)
            };
        }
    }
}
