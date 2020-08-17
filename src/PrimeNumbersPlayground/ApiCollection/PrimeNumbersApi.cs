using System;
using System.Net.Http;
using System.Threading.Tasks;
using PrimeNumbersPlayground.ApiCollection.Infrastructure;
using PrimeNumbersPlayground.Settings;

namespace PrimeNumbersPlayground.ApiCollection
{
    public class PrimeNumbersApi : BaseHttpClientWithFactory, IPrimeNumbersApi
    {
        private readonly IApiSettings m_Settings;

        public PrimeNumbersApi(IHttpClientFactory factory, IApiSettings settings)
            : base(factory)
        {
            m_Settings = settings;
        }

        public async Task<string> GetNumberPrimality(string number)
        {
            var message = new HttpRequestBuilder(m_Settings.BaseAddress)
                                .SetPath(m_Settings.NumbersPath)
                                .AddToPath("GetNumberPrimality")
                                .AddToPath(number)
                                .HttpMethod(HttpMethod.Get)
                                .GetHttpMessage();

            return await SendRequest<string>(message);
        }

        public async Task<string> GetNextPrimeNumber(string number)
        {
            var message = new HttpRequestBuilder(m_Settings.BaseAddress)
                                .SetPath(m_Settings.NumbersPath)
                                .AddToPath("GetNextPrimeNumber")
                                .AddToPath(number)
                                .HttpMethod(HttpMethod.Get)
                                .GetHttpMessage();

            return await SendRequest<string>(message);
        }

        public async Task<string> GetNextPrimeNumberViaDb(string number)
        {
            var message = new HttpRequestBuilder(m_Settings.BaseAddress)
                                .SetPath(m_Settings.NumbersPath)
                                .AddToPath("GetNextPrimeNumberViaDb")
                                .AddToPath(number)
                                .HttpMethod(HttpMethod.Get)
                                .GetHttpMessage();

            return await SendRequest<string>(message);
        }
    }
}
