using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using xamarin_monthly_01.Core.Api.Services;
using xamarin_monthly_01.Core.Models;
using System.Linq;

namespace xamarin_monthly_01.Core.ViewModels.Home
{
    public class HomePageModel : BaseViewModel
    {
        private readonly IWeatherService _weatherService;

        public HomePageModel(IWeatherService weatherService)
        {
            ShadowsNavigateCommand = new MvxAsyncCommand(ExecuteShadowsNavigate);
            SearchCommand = new MvxCommand(() => _ = ExecuteSearch());
            NavigateToCityCommand = new MvxAsyncCommand<LocationInfo>(ExecuteNavigateToCity);
            _weatherService = weatherService;
        }
        public ObservableCollection<LocationInfo> Locations { get; } = new();

        public IMvxCommand ShadowsNavigateCommand { get; }

        private Task ExecuteShadowsNavigate()
            => Navigation.Navigate<ShadowsPageModel>();

        private string _searchPhrase;
        public string SearchPhrase
        {
            get => _searchPhrase;
            set => SetProperty(ref _searchPhrase, value);
        }

        public IMvxCommand SearchCommand { get; }

        private async Task ExecuteSearch()
        {
            var result = await _weatherService.SearchLocation(SearchPhrase);
            if(result.Success)
            {
                Locations.Clear();
                result.Entity?.Locations.ToList().ForEach(x => Locations.Add(x));
            }
        }

        public IMvxCommand NavigateToCityCommand { get; }

        private Task ExecuteNavigateToCity(LocationInfo location)
            => Navigation.Navigate<WeatherPageModel, WeatherNavigateParam>(new()
            {
                LocationId = location.Id,
            });
    }
}
