using System;
using System.Threading.Tasks;

using BlazorRemoteLinq.Web.Repository;
using BlazorRemoteLinq.Web.Services;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorRemoteLinq.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<IOrderService, OrderService>();

            builder.Services.AddHttpClient<IRemoteRepository, RemoteRepository>(o =>
            {
                o.BaseAddress = new Uri(builder.Configuration["QueryApi:BaseAddress"]);
            });

            await builder.Build().RunAsync();
        }
    }
}
