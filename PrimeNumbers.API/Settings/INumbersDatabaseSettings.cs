using System;

namespace PrimeNumbers.API.Settings
{
    /// <summary>
    /// Use to inject data from appsettings.json for the Database in classes.
    /// </summary>
    public interface INumbersDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string CollectionName { get; set; }
    }
}
