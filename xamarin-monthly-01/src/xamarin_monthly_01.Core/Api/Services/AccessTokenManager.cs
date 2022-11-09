using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_monthly_01.Core.Api.Services
{
    public class AccessTokenManager : IAccessTokenManager
    {
        public IDictionary<string, string> GetAuthHeaders()
        {
            return new Dictionary<string, string>()
            {
                ["x-rapidapi-host"] = "foreca-weather.p.rapidapi.com",
                ["x-rapidapi-key"] = "17745ad3d0msh343e0448fed4c5fp1c9057jsn5ac7712201ac"
            };
        }
    }
}
