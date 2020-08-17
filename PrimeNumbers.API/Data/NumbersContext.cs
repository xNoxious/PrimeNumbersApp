using System;
using MongoDB.Driver;
using PrimeNumbers.API.Entities;
using PrimeNumbers.API.Settings;

namespace PrimeNumbers.API.Data
{
    public class NumbersContext : INumbersContext
    {
        public NumbersContext(INumbersDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            PrimeNumberCouples = database.GetCollection<PrimeNumberCouple>(settings.CollectionName);

            NumbersContextSeed.SeedData(PrimeNumberCouples);
        }

        public IMongoCollection<PrimeNumberCouple> PrimeNumberCouples { get; }
    }
}
