using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using System.Collections.Generic;
using System.Linq;

namespace StefansSuperShop.Pages.Admin
{
    public class NewsletterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Newsletter> Newsletters { get; set; }

        public class Newsletter
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Message { get; set; }

        }

        public NewsletterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Newsletters = _context.Newsletters.Select(e => new Newsletter
            {
                Id = e.Id,
                Title = e.Title,
                Message = e.Message

            }).ToList();
        }
    }
}
