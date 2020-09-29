using System.Linq;

using BlazorRemoteLinq.Shared.Entities;

namespace BlazorRemoteLinq.Web.Repository
{
    public interface IRemoteRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<OrderItem> OrderItems { get; }
    }
}
