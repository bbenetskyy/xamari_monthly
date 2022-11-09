using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xamarin_monthly_01.Core.Api.Dto;

namespace xamarin_monthly_01.Core.Models
{
    public class Observations
    {
        public IList<Observation> ObservationList { get; set; }

        public static implicit operator Observations(ObservationsDto dto) => dto is null ? null : new()
        {
            ObservationList = dto.Observations?.Select(x => (Observation)x).ToList(),
        };
    }
}
