using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_monthly_01.Core.Api.Services;
using xamarin_monthly_01.Core.Models;

namespace xamarin_monthly_01.Core.ViewModels.Home
{
    public class WeatherPageModel : BaseViewModel<WeatherNavigateParam>
    {
        private readonly IWeatherService _weatherService;
        private WeatherNavigateParam _param;

        public WeatherPageModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public override void Prepare(WeatherNavigateParam parameter)
        {
            _param = parameter;
        }

        public LocationInfo _locationInfo;
        public LocationInfo LocationInfo
        {
            get => _locationInfo;
            set => SetProperty(ref _locationInfo, value);
        }
        public Observations _observations;
        public Observations Observations
        {
            get => _observations;
            set => SetProperty(ref _observations, value);
        }
        public CurrentWeather _currentWeather;
        public CurrentWeather CurrentWeather
        {
            get => _currentWeather;
            set => SetProperty(ref _currentWeather, value);
        }

        public override async Task Initialize()
        {
            var result = await _weatherService.GetLocationInfo(_param.LocationId);
            if(result.Success)
            {
                LocationInfo = result.Entity;
            }
            var result2 = await _weatherService.GetLastestObservations(_param.LocationId);
            if (result.Success)
            {
                Observations = result2.Entity;
            }
            var result3 = await _weatherService.GetCurrentWeather(_param.LocationId);
            if (result.Success)
            {
                CurrentWeather = result3.Entity;
            }
        }
    }
}
