using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StefansSuperShop.Data;

namespace StefansSuperShop.Pages
{
    public class SubscriberModel : PageModel
    {
        private readonly StefansSuperShop.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public SubscriberModel(StefansSuperShop.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        [EmailAddress]
        public string Epost { get; set; }
        public string Id { get; set; }

        [BindProperty]
        public Subscriber Subscriber { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subscribers.Add(Subscriber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostNewsletterLayoutAsync()
        {
            Subscriber model;
            var user = _userManager.GetUserAsync(User).Result != null ? _userManager.GetUserAsync(User).Result : null;

            //Kolla om epost är valid(Typ)
            if (Epost == null)
            {
                return Page();
                //return RedirectToPage("./Index");
            }
            
            //Kolla om epost finns registrerad
            if (!_context.Subscribers.ToList().Exists(x => x.Email == Epost))
             {
                model = new Subscriber
                {
                    Email = Epost,

                };

                
            }
            else
            {
                return Page();
            }

            //Checka om user är invalid
            if (user != null)
            {
                model.User = user;
                model.UserId = user.Id;
            }
            //Checka om user redan är registrerad(Bara tills Newsletter markup tas bort när inloggad och registrerad)
            if(_context.Subscribers.ToList().Exists(x => x.UserId == user.Id))
            {
                return Page();
            }


            _context.Subscribers.Add(model);
            await _context.SaveChangesAsync();

            return Page();
        }

    }
}
