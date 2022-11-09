using xamarin_monthly_01.Core.Api.Dto;

namespace xamarin_monthly_01.Core.Models
{
    public class Weather
    {
        public string Time { get; set; }
        public string Symbol { get; set; }
        public string SymbolPhrase { get; set; }
        public int Temperature { get; set; }
        public int FeelsLikeTemp { get; set; }
        public int RelHumidity { get; set; }
        public int DewPoint { get; set; }
        public int WindSpeed { get; set; }
        public string WindDirString { get; set; }
        public int WindGust { get; set; }
        public int PrecipProb { get; set; }
        public int PrecipRate { get; set; }
        public int Cloudiness { get; set; }
        public int ThunderProb { get; set; }
        public int UvIndex { get; set; }
        public float Pressure { get; set; }
        public int Visibility { get; set; }

        public static implicit operator Weather(WeatherDto dto) => dto is null ? null : new()
        {
            Time = dto.Time,
            Symbol = dto.Symbol,
            SymbolPhrase = dto.SymbolPhrase,
            Temperature = dto.Temperature,
            FeelsLikeTemp = dto.FeelsLikeTemp,
            RelHumidity = dto.RelHumidity,
            DewPoint = dto.DewPoint,
            WindSpeed = dto.WindSpeed,
            WindDirString = dto.WindDirString,
            WindGust = dto.WindGust,
            PrecipProb = dto.PrecipProb,
            PrecipRate = dto.PrecipRate,
            Cloudiness = dto.Cloudiness,
            ThunderProb = dto.ThunderProb,
            UvIndex = dto.UvIndex,
            Pressure = dto.Pressure,
            Visibility = dto.Visibility,
        };
    }
}
