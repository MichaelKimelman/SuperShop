using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StefansSuperShop.Data;
using StefansSuperShop.Services;

namespace StefansSuperShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        public readonly IKrisInfoService _krisInfoService;


        public class TrendingCategory
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public List<TrendingCategory> TrendingCategories { get; set; }

        public List<Product> NewProducts { get; set; }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


 
        public List<KrisListItem> Items { get; set; }

        public class KrisListItem
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string ImageUrl { get; set; }

        }



        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, IKrisInfoService krisInfoService)
        {
            _logger = logger;
            _context = context;
            _krisInfoService = krisInfoService;
        }

        public void OnGet()
        {
            TrendingCategories = _context.Categories.Take(3).Select(c =>
                new TrendingCategory { Id = c.CategoryId, Name = c.CategoryName }
            ).ToList();

            Items = _krisInfoService.GetAllKrisInformation().Select(r => new KrisListItem
            {
                Id = r.Id,
                Title = r.Title,
                ImageUrl = r.ImageUrl


            }).Take(10).ToList();


        }



}
}
