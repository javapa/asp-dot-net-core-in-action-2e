using AddRazorPages.Entities;
using AddRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using System;

namespace AddRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IQuoteService quoteService;
        private readonly LinkGenerator linkGenerator;
        public List<Quote> Quotes;
        public Quote Quote;
        public string[] URLS;

        public IndexModel(IQuoteService quoteService, LinkGenerator linkGenerator)
        {
            this.quoteService = quoteService;
            this.linkGenerator = linkGenerator;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var url1 = Url.Page("Index", new { id = 5 });
            var url2 = linkGenerator.GetPathByPage(HttpContext, "Contact", null);
            var url3 = linkGenerator.GetPathByPage("/Contact", null);
            var url4 = linkGenerator.GetUriByPage("/Contact", null, null, "https", new HostString("localhost", 44393));
            var url5 = Url.Page("/Index", new { id = 5 });
            var url6 = Url.IsLocalUrl("/Index");
            var url7 = Url.IsLocalUrl("Index");
            var url8 = Url.IsLocalUrl("~/Index");


            URLS = new string[] { url1, url2, url3, url4, url5, url6.ToString(), url7.ToString(), url8.ToString() };

            var quote = await quoteService.GetQuoteById(id);
            Quote = quote ?? await quoteService.GetRandomQuote();
            return Page();
        }

        public async Task<IActionResult> OnGetCustomer(int id)
        {
            string text = null;
            string author = null;

            if (id == 5)
            {
                text = "the id is 5";
                author = "the author is 5";
            }
            else
            {
                text = "the id is not 5";
                author = "the author is not 5";
            }
            Quote = new Quote(3,text,author);
            URLS = new string[0];
            return Page();
        }
    }
}
