using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xamarin_monthly_01.Core.Api.Dto;

namespace xamarin_monthly_01.Core.Models
{
    public class Search
    {
        public IList<LocationInfo> Locations { get; set; }

        public static implicit operator Search(SearchDto dto) => dto is null ? null : new()
        {
            Locations = dto.Locations?.Select(x => (LocationInfo)x).ToList()
        };
    }
}
