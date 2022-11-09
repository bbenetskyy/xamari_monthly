using System.Threading.Tasks;
using xamarin_monthly_01.Core.Api.Dto;

namespace xamarin_monthly_01.Core.Api.Services
{
    public interface IWeatherService
    {
        Task<RestResult<CurrentWeatherDto>> GetCurrentWeather(int locationId, float altitude = 0, string temperatureUnit = null, string windUnit = null, string timezone = null, string language = null);
        Task<RestResult<ObservationsDto>> GetLastestObservations(int locationId, string language = null);
        Task<RestResult<LocationInfoDto>> GetLocationInfo(int locationId);
        Task<RestResult<SearchDto>> SearchLocation(string city, string country = null, string language = null);
    }
}
