using System;
using System.Threading.Tasks;

namespace PrimeNumbers.API.Repositories
{
    public interface IPrimeNumberCoupleRepository
    {
        Task<int> GetNextPrimeNumberViaDb(int givenNumber);
    }
}
