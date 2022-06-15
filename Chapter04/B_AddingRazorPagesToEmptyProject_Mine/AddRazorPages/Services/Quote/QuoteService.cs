using AddRazorPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddRazorPages.Services
{
    public class QuoteService : IQuoteService
    {
        private static readonly List<Quote> quotes = new List<Quote>
        {
            new Quote(1, "Action is the antidote to despair.", "Joan Baez"),
            new Quote(2, "The only place where success comes before work is in the dictionary.", "Vidal Sassoon"),
            new Quote(3, "Think continually about what you want, not about the Things you fear.", "Brian Tracy"),
            new Quote(4, "Success is getting what you want. Hapiness is wanting what you get. ", "W.P. Kinsella"),
            new Quote(5, "Everything you ever wanted is on the other side of fear.", "George Addair"),
            new Quote(6, "Few things are harder to put up with then a good example.", "Mark Twain")
        };

        public async Task<Quote> GetQuoteById(int id)
        {
           return quotes.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            return quotes;
        }

        public async Task<Quote> GetRandomQuote()
        {
            var random = new Random();
            return quotes[random.Next(quotes.Count)];
        }
    }
}
