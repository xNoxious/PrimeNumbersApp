using System;
using MongoDB.Driver;
using PrimeNumbers.API.Entities;

namespace PrimeNumbers.API.Data
{
    public interface INumbersContext
    {
        IMongoCollection<PrimeNumberCouple> PrimeNumberCouples { get; }
    }
}
