/*
 * Original code written by Jonathan Danylko in his 'Refactoring HttpClient with ASP.NET Core 3.1' book
 */
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace PrimeNumbersPlayground.ApiCollection.Infrastructure
{
    public abstract class BaseHttpClientWithFactory
    {
        private readonly IHttpClientFactory _factory;

        public Uri BaseAddress { get; set; }

        public string BasePath { get; set; }

        public BaseHttpClientWithFactory(IHttpClientFactory factory)
        => _factory = factory;

        private HttpClient GetHttpClient()
        {
            return _factory.CreateClient();
        }

        public virtual async Task<string> SendRequest<T>(HttpRequestMessage request)
        {
            var client = GetHttpClient();
            var response = await client.SendAsync(request);
            string result = string.Empty;
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

        protected virtual IEnumerable<MediaTypeFormatter> GetFormatters()
        {
            // Make JSON the default
            return new List<MediaTypeFormatter> { new JsonMediaTypeFormatter() };
        }
    }
}
