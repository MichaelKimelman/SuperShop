using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace StefansSuperShop.Data
{
    public class ExtendedUser : IdentityUser
    {
        public ICollection<Products> Wishlist { get; set; }
    }
}
