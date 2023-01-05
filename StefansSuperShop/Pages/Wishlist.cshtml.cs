using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StefansSuperShop.Data;

namespace StefansSuperShop.Pages
{
    public class WishlistModel : PageModel
    {
        private readonly StefansSuperShop.Data.ApplicationDbContext _context;
        private readonly UserManager<ExtendedUser> _userManager;
        private readonly SignInManager<ExtendedUser> _signInManager;

        public WishlistModel(StefansSuperShop.Data.ApplicationDbContext context, UserManager<ExtendedUser> userManager, SignInManager<ExtendedUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public ICollection<WishlistItem> Wishlist { get; set; }
        public ExtendedUser _User { get; set; }
        public class WishlistItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal? Price { get; set; }

        }

        public async Task OnGetAsync()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = _userManager.GetUserAsync(User).Result;
                _User = user;//Kanske tas bort, används egentligen inte nu
                var products = from p in _context.Products
                               join wli in _context.Wishlist on p.ProductId equals wli.ProductId
                               where wli.ExtendedUserId == user.Id
                               select p;

                Wishlist = products.Select(p => new WishlistItem
                {
                    Id = p.ProductId,
                    Name = p.ProductName,
                    Price = p.UnitPrice,
                }).ToList();      
            }
            
        }
        public async Task<IActionResult> OnPostCreateAsync(int productId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user != null)
            {
                if(_context.Products.Any(x => x.ProductId == productId))
                {
                    var Wishlist = new Wishlist()
                    {
                        ProductId = productId,
                        ExtendedUserId = user.Id
                    };

                    _context.Wishlist.Add(Wishlist);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            return Page();
        }
    }
}
