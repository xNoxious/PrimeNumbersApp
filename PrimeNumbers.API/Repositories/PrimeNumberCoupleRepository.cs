using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using PrimeNumbers.API.Data;

namespace PrimeNumbers.API.Repositories
{
    public class PrimeNumberCoupleRepository : IPrimeNumberCoupleRepository
    {
        private readonly INumbersContext m_Context;

        public PrimeNumberCoupleRepository(INumbersContext context)
        {
            m_Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> GetNextPrimeNumberViaDb(int givenNumber)
        {
            var numberCouple = await m_Context
                                .PrimeNumberCouples
                                .Find(n => n.GivenPrimeNumber == givenNumber)
                                .FirstOrDefaultAsync();
            int defaultVal = 0;

            if (numberCouple != null)
            {
                defaultVal = numberCouple.NextPrimeNumber;
            }

            return defaultVal;
        }
    }
}
