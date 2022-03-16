using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using NBG.Services.Clients.REST;
using NBG.Visitor.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth

                //builder.Configuration.Bind("Oidc", options.ProviderOptions);
                builder.Configuration.Bind("Local", options.ProviderOptions);
            });
            builder.Services.AddSingleton<IVisitService, RestVisitService>();
            builder.Services.AddMudServices();

            builder.Services.AddSingleton<ITicketService, RestTicketService>();

            await builder.Build().RunAsync();
        }
    }
}
