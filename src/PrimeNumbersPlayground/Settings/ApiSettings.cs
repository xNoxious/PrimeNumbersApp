using System;

namespace PrimeNumbersPlayground.Settings
{
    public class ApiSettings : IApiSettings
    {
        public string BaseAddress { get; set; }

        public string NumbersPath { get; set; }
    }
}
