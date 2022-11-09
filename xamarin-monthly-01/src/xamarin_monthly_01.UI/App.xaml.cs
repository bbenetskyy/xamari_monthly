using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross;
using MvvmCross.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;
using xamarin_monthly_01.Core.Models;
using xamarin_monthly_01.Core.ViewModels.Home;

namespace xamarin_monthly_01.UI
{
    public class AppStartOption
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Id => $"WEATHER_{LocationId}";
        public string Icon { get; set; }
        public int LocationId { get; set; }
    }

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        private readonly IEnumerable<AppStartOption> _appStartOptions = new[]
        {
            new AppStartOption
            {
                Title = "Warszawa",
                SubTitle = "Pogoda w Warszawie",
                LocationId = 100756135,
                Icon = "ic_mvvmcross_logo"
            },
            new AppStartOption
            {
                Title = "Sosnowiec",
                SubTitle = "Pogoda w Sosnowcu",
                LocationId = 103085128,
                Icon = "ic_mvvmcross_logo"
            },
            new AppStartOption
            {
                Title = "Wrocław",
                SubTitle = "Pogoda we Wrocławiu",
                LocationId = 103081368,
                Icon = "cat"
            },
            new AppStartOption
            {
                Title = "Poznań",
                SubTitle = "Pogoda w Poznaniu",
                LocationId = 103088171,
                Icon = "cat"
            }
        };

        protected override async void OnStart()
        {
            base.OnStart();

            AppActions.OnAppAction += AppActions_OnAppAction;
            try
            {
                await AppActions.SetAsync(_appStartOptions.Select(x =>
                    new AppAction(x.Id, x.Title, x.SubTitle, x.Icon)));
            }
            catch (FeatureNotSupportedException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void AppActions_OnAppAction(object sender, AppActionEventArgs e)
        {
            if (Application.Current != this && Application.Current is App app)
            {
                AppActions.OnAppAction -= app.AppActions_OnAppAction;
                return;
            }
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var _navigation = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
                var appStart = _appStartOptions.Where(x => e.AppAction.Id == x.Id).FirstOrDefault();
                if (appStart is not null)
                {
                    await _navigation.Navigate<WeatherPageModel, WeatherNavigateParam>(new()
                    {
                        LocationId = appStart.LocationId,
                    });
                }
            });
        }
    }
}
