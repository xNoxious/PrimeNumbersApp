using System;

namespace PrimeNumbersPlayground.Settings
{
    public interface IApiSettings
    {
        public string BaseAddress { get; set; }

        public string NumbersPath { get; set; }
    }
}
