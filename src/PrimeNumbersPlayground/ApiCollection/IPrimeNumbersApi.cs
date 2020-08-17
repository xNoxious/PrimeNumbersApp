using System;
using System.Threading.Tasks;

namespace PrimeNumbersPlayground.ApiCollection
{
    public interface IPrimeNumbersApi
    {
        Task<string> GetNumberPrimality(string number);

        Task<string> GetNextPrimeNumber(string number);

        Task<string> GetNextPrimeNumberViaDb(string number);
    }
}
