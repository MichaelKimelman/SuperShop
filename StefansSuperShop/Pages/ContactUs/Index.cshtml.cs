using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace StefansSuperShop.Pages.ContactUs
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
             
        }

        public void OnPost()
        {

            var name = Request.Form["name"];
            var email = Request.Form["email"];
            var subject = Request.Form["subject"];
            var text = Request.Form["text"];
            ViewData["confirmation"] = $"Thank you for your message.We will contact you in 2-3 working days";

        }
    }
}
