using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PrimeNumbers.API.Entities
{
    public class PrimeNumberCouple
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int GivenPrimeNumber { get; set; }

        public int NextPrimeNumber { get; set; }
    }
}
