using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using xamarin_monthly_01.Core.Api.Dto;

namespace xamarin_monthly_01.Core.Api.Clients
{
    public interface IWeatherClient
    {
        [Get("/location/search/{city}?country={country}")]
        public Task<IApiResponse<SearchDto>> SearchLocation(
            string city,
            string country,
            [AliasAs("lang")]string language);

        [Get("/location/{locationId}")]
        public Task<IApiResponse<LocationInfoDto>> LocationInfo(int locationId);

        [Get("/observation/latest/{locationId}")]
        public Task<IApiResponse<ObservationsDto>> GetLastestObservations(
            int locationId,
            [AliasAs("lang")] string language);

        [Get("/current/{locationId}")]
        public Task<IApiResponse<CurrentWeatherDto>> GetCurrentWeather(
            int locationId,
            [AliasAs("alt")] float altitude,
            [AliasAs("tempunit")] string temperatureUnit,
            [AliasAs("windunit")] string windUnit,
            [AliasAs("tz")] string timezone,
            [AliasAs("lang")] string language);
    }
}
