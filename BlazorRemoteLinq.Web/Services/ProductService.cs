using System.Collections.Generic;
using System.Threading.Tasks;

using BlazorRemoteLinq.Shared.Entities;
using BlazorRemoteLinq.Web.Repository;

using Remote.Linq;

namespace BlazorRemoteLinq.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IRemoteRepository _remoteRepository;

        public ProductService(IRemoteRepository remoteRepository)
        {
            _remoteRepository = remoteRepository;
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = await _remoteRepository.Products.SingleOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            List<Product> products = await _remoteRepository.Products.Include(x => x.ProductCategory).ToListAsync();
            return products;
        }
    }
}
