using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Services;
using System.Collections.Generic;
using System.Linq;

namespace StefansSuperShop.Pages
{
    public class KrisInfoListModel : PageModel
    {
        //public readonly IKrisInfoService _krisInfoService;

        //public KrisInfoListModel(IKrisInfoService krisInfoService)
        //{
        //    _krisInfoService = krisInfoService;
        //}
        //public List<KrisListItem> Items { get; set; }



        //public class KrisListItem
        //{
        //    public string Id { get; set; }
        //    public string Title { get; set; }
        //    public string ImageUrl { get; set; }

        //}

        //public void OnGet()
        //{
        //    Items = _krisInfoService.GetAllKrisInformation().Select(r => new KrisListItem
        //    {
        //        Id = r.Id,
        //        Title = r.Title,
        //        ImageUrl = r.ImageUrl

                
        //    }).Take(10).ToList();



        //}
    }
}
