using System;
using System.Collections.Generic;
using MongoDB.Driver;
using PrimeNumbers.API.Entities;

namespace PrimeNumbers.API.Data
{
    public class NumbersContextSeed
    {
        public static void SeedData(IMongoCollection<PrimeNumberCouple> primeNumberCoupleCollection)
        {
            bool existsData = primeNumberCoupleCollection.Find(p => true).Any();

            if (!existsData)
            {
                primeNumberCoupleCollection.InsertManyAsync(ProvisionNumberCouples());
            }
        }

        private static IEnumerable<PrimeNumberCouple> ProvisionNumberCouples()
        {
            return new List<PrimeNumberCouple>()
            {
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 1,
                    NextPrimeNumber = 2
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 2,
                    NextPrimeNumber = 3
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 3,
                    NextPrimeNumber = 5
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 4,
                    NextPrimeNumber = 5
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 5,
                    NextPrimeNumber = 7
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 6,
                    NextPrimeNumber = 7
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 7,
                    NextPrimeNumber = 11
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 8,
                    NextPrimeNumber = 11
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 9,
                    NextPrimeNumber = 11
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 10,
                    NextPrimeNumber = 11
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 11,
                    NextPrimeNumber = 13
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 12,
                    NextPrimeNumber = 13
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 13,
                    NextPrimeNumber = 17
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 14,
                    NextPrimeNumber = 17
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 15,
                    NextPrimeNumber = 17
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 16,
                    NextPrimeNumber = 17
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 17,
                    NextPrimeNumber = 19
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 18,
                    NextPrimeNumber = 19
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 19,
                    NextPrimeNumber = 23
                },
                new PrimeNumberCouple()
                {
                    GivenPrimeNumber = 20,
                    NextPrimeNumber = 23
                }
            };
        }
    }
}
