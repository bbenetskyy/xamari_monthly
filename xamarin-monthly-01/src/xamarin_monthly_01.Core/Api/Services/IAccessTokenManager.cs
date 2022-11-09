using System.Collections.Generic;

namespace xamarin_monthly_01.Core.Api.Services
{
    public interface IAccessTokenManager
    {
        IDictionary<string, string> GetAuthHeaders();
    }
}
