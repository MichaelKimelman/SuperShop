using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Services;

namespace StefansSuperShop.Pages
{
    public class KrisInfoArticleModel : PageModel
    {
        private readonly IKrisInfoService _krisInfoService;
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }

        public KrisInfoArticleModel(IKrisInfoService krisInfoService)
        {
            _krisInfoService = krisInfoService;
        }

        public void OnGet(string articleid)
        {
            var krisInfo = _krisInfoService.GetKrisInformation(articleid);
            Title = krisInfo.Title;
            Text = krisInfo.Text;
            Link = krisInfo.LinkUrl;
        }
    }
}
