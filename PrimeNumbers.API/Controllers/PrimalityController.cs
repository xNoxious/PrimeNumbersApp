using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeNumbers.API.Services;

namespace PrimeNumbers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimalityController : ControllerBase
    {
        private readonly INumbersService m_Service;
        private readonly ILogger<PrimalityController> m_Logger;

        public PrimalityController(INumbersService service, ILogger<PrimalityController> logger)
        {
            m_Service = service ?? throw new ArgumentNullException(nameof(service));
            m_Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("[action]/{number}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public ActionResult<int> GetNumberPrimality(int number)
        {
            var isPrime = m_Service.IsNumberPrime(number);
            return Ok(isPrime);
        }

        [HttpGet]
        [Route("[action]/{number}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public ActionResult<int> GetNextPrimeNumber(int number)
        {
            var nextPrime = m_Service.GetNextPrimeNumber(number);
            return Ok(nextPrime);
        }

        [HttpGet]
        [Route("[action]/{number}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> GetNextPrimeNumberViaDb(int number)
        {
            var nextNumber = await m_Service.FetchNextPrimeNumberFromDb(number);

            if (nextNumber == 0)
            {
                m_Logger.LogError($"No information found about given number {number}.");
                return Ok("Given number is not present in database.");
            }

            return Ok(nextNumber);
        }
    }
}
