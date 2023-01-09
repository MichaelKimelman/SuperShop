using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StefansSuperShop.Data;
using Microsoft.Extensions.Logging;

namespace StefansSuperShop.Pages
{
    public class BasePageModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private ILogger<PrivacyModel> _privacyLogger;
        private ILogger<IndexModel> _indexLogger;


        public BasePageModel(ILogger<PrivacyModel> logger)
        {
            _privacyLogger = logger;
        }

        public BasePageModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _indexLogger = logger;
            _context = context;
        }

        public BasePageModel(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public bool IsAlreadySubscriber { get; set; }


        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (_signInManager.IsSignedIn(User) == null)
            {
                var user = _userManager.GetUserAsync(User).Result;


                if (user != null && _context.Subscribers.Any(x => x.UserId == user.Id))
                {
                    IsAlreadySubscriber = true;

                }
                if (user != null && !_context.Subscribers.Any(x => x.UserId == user.Id))
                {
                    IsAlreadySubscriber = false;

                }


            }
            else
            {
                IsAlreadySubscriber = false;
            }
            

            base.OnPageHandlerExecuting(context);
        }
    }
}
