using AddRazorPages.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddRazorPages.Services
{
    public interface IQuoteService
    {
        Task<IEnumerable<Quote>> GetQuotes();

        Task<Quote> GetRandomQuote();
    }
}
