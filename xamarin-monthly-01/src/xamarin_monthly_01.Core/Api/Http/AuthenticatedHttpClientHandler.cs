using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace xamarin_monthly_01.Core.Api.Http
{
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly Func<IDictionary<string, string>> _getAuthInfo;

        public AuthenticatedHttpClientHandler(Func<IDictionary<string, string>> getAuthInfo)
        {
            _getAuthInfo = getAuthInfo ?? throw new ArgumentNullException(nameof(getAuthInfo));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authHeaders = _getAuthInfo();

            authHeaders.Select(x => (x.Key, x.Value))
                .ToList()
                .ForEach(x => request.Headers.Add(x.Key, x.Value));

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
