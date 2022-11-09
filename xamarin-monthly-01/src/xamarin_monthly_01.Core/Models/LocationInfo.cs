using System;
using System.Collections.Generic;
using System.Text;
using xamarin_monthly_01.Core.Api.Dto;

namespace xamarin_monthly_01.Core.Models
{
    public class LocationInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
        public string AdminArea { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }

        public static implicit operator LocationInfo(LocationInfoDto dto) => dto is null ? null : new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Country = dto.Country,
            Timezone = dto.Timezone,
            AdminArea = dto.AdminArea,
            Lon = dto.Lon,
            Lat = dto.Lat,
        };
    }
}
