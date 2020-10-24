using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace GeoСoordination
{
    public static class Http
    {
        private static readonly HttpClient _HttpClient;

        static Http()
        {
            _HttpClient = new HttpClient();
        }

        public async static Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> httpHeaders, CancellationToken CancellationToken = default(CancellationToken))
        {
            using (HttpRequestMessage rq = new HttpRequestMessage())
            {
                rq.Method = HttpMethod.Get;
                rq.RequestUri = new Uri(url);

                if (httpHeaders != null)
                {
                    foreach (var headers in httpHeaders)
                    {
                        rq.Headers.Add(headers.Key, headers.Value);
                    }
                }
                return await _HttpClient.SendAsync(rq);
            }
        }
    }
}
