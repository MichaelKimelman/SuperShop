using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StefansSuperShop.Data;

namespace StefansSuperShop.Pages.Admin.CategoriesCRUD
{
    public class IndexModel : PageModel
    {
        private readonly StefansSuperShop.Data.ApplicationDbContext _context;
        public IList<CategoryRow> Categories { get; set; }
        public class CategoryRow
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public IndexModel(StefansSuperShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.Select(e => new CategoryRow
            {
                Id = e.CategoryId,
                Name = e.CategoryName,
                Description = e.Description,
            }).ToListAsync();
        }
    }
}
