using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xamarin_monthly_01.Core.Api.Services;

namespace xamarin_monthly_01.Core.Api.Http
{
    public class HttpClientFactory : IHttpClientFactory
    {
        #region Fields
        private readonly IAccessTokenManager _accessTokenManager;
        private string _baseUrl;
        private HttpClient _httpClientAuthorised;
        private HttpClient _httpClientNotAuthorised;
        #endregion Fields

        #region Constructors

        public HttpClientFactory(IAccessTokenManager accessTokenManager)
        {
            _accessTokenManager = accessTokenManager;
        }
        #endregion Constructors

        #region Public Methods

        public HttpClient CreateHttpClient(string baseUrl, bool requiresAuthorisation)
        {
            _baseUrl = baseUrl;

            HttpClient httpClient = requiresAuthorisation
                ? CreateAuthorisedHttpClient()
                : CreateNotAuthorisedHttpClient();
            return httpClient;
        }

        #endregion Public Methods

        #region Private Methods
        private HttpClient CreateAuthorisedHttpClient()
        {
            if (_httpClientAuthorised == null || _httpClientAuthorised.BaseAddress.AbsoluteUri != _baseUrl)
            {
                HttpMessageHandler handler = new AuthenticatedHttpClientHandler(_accessTokenManager.GetAuthHeaders);
#if DEBUG
                handler = new LoggerHttpMessageHandler(handler);
#endif
                _httpClientAuthorised = new HttpClient(handler)
                {
                    BaseAddress = new Uri(_baseUrl)
                };
            }
            return _httpClientAuthorised;
        }
        private HttpClient CreateNotAuthorisedHttpClient()
        {
            if (_httpClientNotAuthorised == null || _httpClientNotAuthorised.BaseAddress.AbsoluteUri != _baseUrl)
            {
#if DEBUG
                HttpMessageHandler handler = new HttpClientHandler();
                handler = new LoggerHttpMessageHandler(handler);
                _httpClientNotAuthorised = new HttpClient(handler);
#else
                _httpClientNotAuthorised = new HttpClient();
#endif

                _httpClientNotAuthorised.BaseAddress = new Uri(_baseUrl);
            }
            return _httpClientNotAuthorised;
        }
        #endregion Private Methods
    }
}
