using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PrimeNumbersPlayground.ApiCollection;

namespace PrimeNumbersPlayground.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPrimeNumbersApi m_NumbersApi;

        public IndexModel(IPrimeNumbersApi numbersApi)
        {
            m_NumbersApi = numbersApi ?? throw new ArgumentNullException(nameof(numbersApi));
        }

        public string PrimeNumberResult = string.Empty;
        public int GivenNumber = 0;

        public async Task<IActionResult> OnPostNumberPrimality(string number)
        {
            PrimeNumberResult = await m_NumbersApi.GetNumberPrimality(number);
            return Page();
        }

        public async Task<IActionResult> OnPostNextPrimeNumber(string number)
        {
            PrimeNumberResult = await m_NumbersApi.GetNextPrimeNumber(number);
            return Page();
        }

        public async Task<IActionResult> OnPostNextPrimeNumberViaDb(string number)
        {
            PrimeNumberResult = await m_NumbersApi.GetNextPrimeNumberViaDb(number);
            return Page();
        }
    }
}
