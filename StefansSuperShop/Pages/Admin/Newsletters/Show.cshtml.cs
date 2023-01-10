using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using System.Collections.Generic;
using System.Linq;

namespace StefansSuperShop.Pages.Admin.Newsletters
{
    public class ShowModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Subscribers> Emails { get; set; }

        public class Subscribers
        {
            public int Id { get; set; }
            public string Email { get; set; }

        }

        public ShowModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            var query = from s in _context.Subscribers
                        join ns in _context.NewsletterSubscribers on s.Id equals ns.SubscriberId
                        where ns.NewsletterId == id
                        select s;

            Emails = query.Select(s => new Subscribers
            {
                Id = s.Id,
                Email = s.Email

            }).ToList();
        }
    }
}
