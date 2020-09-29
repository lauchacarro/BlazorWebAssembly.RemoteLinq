using System.Threading.Tasks;

using BlazorRemoteLinq.Shared.Models;

namespace BlazorRemoteLinq.Web.Services
{
    public interface IOrderService
    {
        Task<SalesReportModel> GetSalesReport();
    }
}
