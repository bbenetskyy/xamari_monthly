using System;

namespace xamarin_monthly_01.Core.Api.Dto
{
    public class ObservationDto
    {
        public string Station { get; set; }
        public string Distance { get; set; }
        public DateTime Time { get; set; }
        public float Temperature { get; set; }
        public float FeelsLikeTemp { get; set; }
        public string Symbol { get; set; }
        public string WindDirString { get; set; }
        public float WindDir { get; set; }
        public float WindSpeed { get; set; }
        public float WindGust { get; set; }
        public float Pressure { get; set; }
        public float RelHumidity { get; set; }
        public float Visibility { get; set; }
    }
}
