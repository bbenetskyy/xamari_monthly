using System;
using System.Collections.Generic;
using System.Text;
using xamarin_monthly_01.Core.Api.Dto;

namespace xamarin_monthly_01.Core.Models
{
    public class CurrentWeather
    {
        public Weather Current { get; set; }

        public static implicit operator CurrentWeather(CurrentWeatherDto dto) => dto is null ? null : new()
        {
            Current = dto.Current,
        };
    }
}
