using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

using Aqua.Dynamic;

using BlazorRemoteLinq.Shared.Entities;

using Newtonsoft.Json;

using Remote.Linq;
using Remote.Linq.Expressions;

namespace BlazorRemoteLinq.Web.Repository
{
    public class RemoteRepository : IRemoteRepository
    {
        private readonly HttpClient _httpClient;
        private readonly Func<Expression, Task<IEnumerable<DynamicObject>>> _dataProvider;

        public RemoteRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _dataProvider = DataProvider;
        }


        public IQueryable<Product> Products => RemoteQueryable.Factory.CreateQueryable<Product>(_dataProvider);
        public IQueryable<OrderItem> OrderItems => RemoteQueryable.Factory.CreateQueryable<OrderItem>(_dataProvider);


        private async Task<IEnumerable<DynamicObject>> DataProvider(Expression expression)
        {
            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings().ConfigureRemoteLinq(),
            };

            BlazorRemoteLinq.Shared.Query query = new BlazorRemoteLinq.Shared.Query { Expression = expression };
            HttpResponseMessage response = await _httpClient.PostAsync("/api/query", query, formatter);

            response.EnsureSuccessStatusCode();

            IEnumerable<DynamicObject> result = await response.Content.ReadAsAsync<IEnumerable<DynamicObject>>(new[] { formatter });
            return result;
        }
    }
}
