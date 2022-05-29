using AddRazorPages.Entities;
using AddRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IQuoteService quoteService;
        public List<Quote> Quotes;
        public Quote RandomQuote;

        public IndexModel(IQuoteService quoteService)
        {
            this.quoteService = quoteService;
        }

        public async Task OnGet()
        {
            RandomQuote = await quoteService.GetRandomQuote();
        }
    }
}
