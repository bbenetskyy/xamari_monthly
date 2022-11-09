using System;
using System.Collections.Generic;
using System.Text;
using xamarin_monthly_01.Core.Api.Dto;

namespace xamarin_monthly_01.Core.Models
{
    public class Observation
    {
        public string Station { get; set; }
        public string Distance { get; set; }
        public DateTime Time { get; set; }
        public float Temperature { get; set; }
        public float FeelsLikeTemp { get; set; }
        public string Symbol { get; set; }
        public string WindDirString { get; set; }
        public int WindDir { get; set; }
        public float WindSpeed { get; set; }
        public int WindGust { get; set; }
        public float Pressure { get; set; }
        public int RelHumidity { get; set; }
        public int Visibility { get; set; }

        public static implicit operator Observation(ObservationDto dto) => dto is null ? null : new()
        {
            Station = dto.Station,
            Distance = dto.Distance,
            Time = dto.Time,
            Temperature = dto.Temperature,
            FeelsLikeTemp = dto.FeelsLikeTemp,
            Symbol = dto.Symbol,
            WindDirString = dto.WindDirString,
            WindDir = dto.WindDir,
            WindSpeed = dto.WindSpeed,
            WindGust = dto.WindGust,
            Pressure = dto.Pressure,
            RelHumidity = dto.RelHumidity,
            Visibility = dto.Visibility,
        };
    }
}
