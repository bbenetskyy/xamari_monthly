using System.Collections.Generic;
using System.Text;

namespace xamarin_monthly_01.Core.Api.Dto
{
    public class LocationInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
        public string AdminArea { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }
    }
}
