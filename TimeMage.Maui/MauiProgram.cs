using Microsoft.AspNetCore.Components.WebView.Maui;
using TimeMage.ComponentsLibrary;
using Blazored.LocalStorage;
using BlazorStrap;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace TimeMage.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .RegisterBlazorMauiWebView()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            var serverUrl = "https://localhost:44395/"; //TimeMage.Server project running IIS Express profile is set to this SSL localhost.
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(serverUrl) });
            builder.Services.AddHttpClient<SpeechToTextClient>(client => client.BaseAddress = new Uri(serverUrl));
            builder.Services.AddHttpClient<PreloadedIntervalSetsClient>(client => client.BaseAddress = new Uri(serverUrl));
            builder.Services.AddScoped<TimeMageState>();
            builder.Services.AddBlazoredLocalStorage(config =>
                config.JsonSerializerOptions.WriteIndented = true);

            builder.Services.AddBlazorStrap();
            builder.Services.AddBlazorWebView();

            return builder.Build();
        }
    }
}