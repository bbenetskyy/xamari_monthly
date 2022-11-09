namespace xamarin_monthly_01.Core.Api.Dto
{
    public class WeatherDto
    {
        public string Time { get; set; }
        public string Symbol { get; set; }
        public string SymbolPhrase { get; set; }
        public float Temperature { get; set; }
        public float FeelsLikeTemp { get; set; }
        public float RelHumidity { get; set; }
        public float DewPoint { get; set; }
        public float WindSpeed { get; set; }
        public string WindDirString { get; set; }
        public float WindGust { get; set; }
        public float PrecipProb { get; set; }
        public float PrecipRate { get; set; }
        public float Cloudiness { get; set; }
        public float ThunderProb { get; set; }
        public float UvIndex { get; set; }
        public float Pressure { get; set; }
        public float Visibility { get; set; }
    }

}
