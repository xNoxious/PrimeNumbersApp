using System;
using System.Threading.Tasks;

namespace PrimeNumbers.API.Services
{
    public interface INumbersService
    {
        bool IsNumberPrime(int number);

        int GetNextPrimeNumber(int number);

        Task<int> FetchNextPrimeNumberFromDb(int number);
    }
}
