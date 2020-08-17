using System;

namespace PrimeNumbers.API.Settings
{
    public class NumbersDatabaseSettings : INumbersDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
