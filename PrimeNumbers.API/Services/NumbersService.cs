using System;
using System.Threading.Tasks;
using PrimeNumbers.API.Repositories;

namespace PrimeNumbers.API.Services
{
    public class NumbersService : INumbersService
    {
        private readonly IPrimeNumberCoupleRepository m_Repository;

        public NumbersService(IPrimeNumberCoupleRepository repository)
        {
            m_Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public bool IsNumberPrime(int number)
        {
            // Cover edge cases
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetNextPrimeNumber(int number)
        {
            // Base case  
            if (number <= 1)
                return 2;

            int nextPrime = number;
            bool found = false;

            // Loop until IsNumberPrime returns true for a number greater than 'number'
            while (!found)
            {
                nextPrime++;

                if (IsNumberPrime(nextPrime))
                    found = true;
            }

            return nextPrime;
        }

        public async Task<int> FetchNextPrimeNumberFromDb(int number)
        {
            return await m_Repository.GetNextPrimeNumberViaDb(number);
        }
    }
}
