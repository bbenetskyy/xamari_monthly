using System;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Refit;
using Xamarin.Essentials;
using xamarin_monthly_01.Core.Api.Clients;
using xamarin_monthly_01.Core.Api.Http;
using xamarin_monthly_01.Core.Api.Services;
using xamarin_monthly_01.Core.ViewModels.Home;

namespace xamarin_monthly_01.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IHttpClientFactory, HttpClientFactory>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IWeatherService, WeatherService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IAccessTokenManager, AccessTokenManager>();

            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton(() =>
            {
                IHttpClientFactory httpClientManager = Mvx.IoCProvider.Resolve<IHttpClientFactory>();
                return RestService.For<IWeatherClient>(httpClientManager.CreateHttpClient("https://foreca-weather.p.rapidapi.com", true), refitSettings);
            });

            RegisterAppStart<HomePageModel>();
        }
    }
}
