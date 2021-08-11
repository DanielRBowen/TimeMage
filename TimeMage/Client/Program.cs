using Blazored.LocalStorage;
using BlazorStrap;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TimeMage.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddHttpClient<SpeechToTextClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
			builder.Services.AddHttpClient<PreloadedIntervalSetsClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
			builder.Services.AddScoped<TimeMageState>();
			builder.Services.AddBlazoredLocalStorage(config =>
				config.JsonSerializerOptions.WriteIndented = true);

			builder.Services.AddBootstrapCss();

			await builder.Build().RunAsync();
		}
	}
}
