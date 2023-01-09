using System.Collections;
using System.Collections.Generic;

namespace StefansSuperShop.Data
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string? ExtendedUserId { get; set; }
        public ExtendedUser User { get; set; }
        public int? ProductId { get; set; }
        public Products Product { get; set; }
    }
}
