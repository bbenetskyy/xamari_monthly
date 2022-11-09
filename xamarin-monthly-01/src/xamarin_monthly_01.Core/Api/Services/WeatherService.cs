using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using xamarin_monthly_01.Core.Api.Clients;
using xamarin_monthly_01.Core.Api.Dto;

namespace xamarin_monthly_01.Core.Api.Services
{
    public class WeatherService : ServiceBase, IWeatherService
    {
        private readonly IWeatherClient _weatherClient;
        private string _defaultLanguage
            => System.Globalization.CultureInfo
                     .CurrentCulture
                     .TwoLetterISOLanguageName;

        public WeatherService(ILogger<WeatherService> logger,
                              IWeatherClient weatherClient)
            : base(logger)
        {
            _weatherClient = weatherClient;
        }

        public Task<RestResult<SearchDto>> SearchLocation(string city, string country = null, string language = null)
            => InvokeWebRequest(() => _weatherClient.SearchLocation(city, country , language ?? _defaultLanguage));

        public Task<RestResult<LocationInfoDto>> GetLocationInfo(int locationId)
            => InvokeWebRequest(() => _weatherClient.LocationInfo(locationId));

        public Task<RestResult<ObservationsDto>> GetLastestObservations(int locationId, string language = null)
            => InvokeWebRequest(() => _weatherClient.GetLastestObservations(locationId, language ?? _defaultLanguage));

        public Task<RestResult<CurrentWeatherDto>> GetCurrentWeather(
            int locationId,
            float altitude = 0,
            string temperatureUnit = null,
            string windUnit = null,
            string timezone = null,
            string language = null)
            => InvokeWebRequest(() => _weatherClient.GetCurrentWeather(locationId, altitude, temperatureUnit, windUnit, timezone, language ?? _defaultLanguage));
    }
}
