using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            //_User = _userManager.GetUserAsync(User).Result;
        }
        [BindProperty]
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

                Wishlist = await products.Select(p => new WishlistItem
                {
                    Id = p.ProductId,
                    Name = p.ProductName,
                    Price = p.UnitPrice,
                }).ToListAsync();      
            }
            
            
        }
        public async Task<IActionResult> OnPostCreateAsync(int productId)
        {
            var user = _userManager.GetUserAsync(User).Result;//Get User
            if (user != null)//Checka User inte null
            {
                if(_context.Products.Any(x => x.ProductId == productId))//Checka om produkt finns
                {
                        if (!_context.Wishlist.Any(x => x.ExtendedUserId == user.Id && x.ProductId == productId))//Checka att User inte redan har produkt
                        {
                            var Wishlist = new Wishlist()
                            {
                                ProductId = productId,
                                ExtendedUserId = user.Id
                            };

                            _context.Wishlist.Add(Wishlist);
                            await _context.SaveChangesAsync();
                            //return Page();
                            return RedirectToPage("./Admin/Products");
                        }
                        else
                        {
                            return RedirectToPage("./Admin/Products");
                        }
                }
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int wishlistItemId)
        {
            var user = _userManager.GetUserAsync(User).Result;//Get User
            var wishlistitem = await _context.Wishlist.FirstAsync(x => x.ExtendedUserId == user.Id && x.ProductId == wishlistItemId);
            if(wishlistitem != null)
            {
                
                _context.Remove(wishlistitem);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Wishlist");

        }
    }
}
