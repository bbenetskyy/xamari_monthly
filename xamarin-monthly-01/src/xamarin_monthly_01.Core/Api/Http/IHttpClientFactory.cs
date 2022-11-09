using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace xamarin_monthly_01.Core.Api.Http
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient(string baseUrl, bool requiresAuthorisation);
    }
}
