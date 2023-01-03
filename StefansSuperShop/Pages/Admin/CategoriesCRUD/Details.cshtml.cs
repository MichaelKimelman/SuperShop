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
    public class DetailsModel : PageModel
    {
        private readonly StefansSuperShop.Data.ApplicationDbContext _context;

        public DetailsModel(StefansSuperShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categories = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (Categories == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
