using System.Collections.Generic;
using System.Threading.Tasks;

using BlazorRemoteLinq.Shared.Entities;

namespace BlazorRemoteLinq.Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
    }
}
