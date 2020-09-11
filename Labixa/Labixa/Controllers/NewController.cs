using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labixa.Models;
using Outsourcing.Service;
using Outsourcing.Data.Models;
using PagedList;
using Labixa.ViewModels;
using Labixa.Helpers;
using Outsourcing.Core.Common;

namespace Labixa.Controllers
{

    public class NewController : BaseHomeController
    {

        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IWebsiteAttributeService _websiteAttribute;




        public NewController(IBlogService blogService,
            IBlogCategoryService blogCategoryService,
            IWebsiteAttributeService websiteAttribute
            )
        {

            this._blogService = blogService;
            this._blogCategoryService = blogCategoryService;
            this._websiteAttribute = websiteAttribute;

        }
        public ActionResult News(int? page = 1)
        {
            int pageNumb = (page ?? 1);
            int pageSize = 6;
            var list = _blogService.GetBlogs().Where(p=>p.BlogCategoryId == 3 && p.IsAvailable == true).ToPagedList(pageNumb, pageSize);
            var child = _websiteAttribute.GetWebsiteAttributeByName("BannerChild");
            ViewBag.BannerChild = child.LinkUrl;
            return View(list);
        }
        public ActionResult NewsDetail(string Slug)
        {
            var model = _blogService.GetBlogByUrlName(Slug);
            ViewBag.Title = model.Title;
            ViewBag.Description = model.Description;
            ViewBag.Image = model.BlogImage_Default;
            ViewBag.Url = model.Slug;
            var child = _websiteAttribute.GetWebsiteAttributeByName("BannerChild");
            ViewBag.BannerChild = child.LinkUrl;
            return View(model);
        }
        public ActionResult NewsFeatured()
        {

            var model = _blogService.Get3BlogNewsNewest().Where(p=>p.IsAvailable==true).ToList();
            return PartialView("_newRelated", model);
        }

        public ActionResult Recruitment(int? page = 1)
        {
            int pageNumb = (page ?? 1);
            int pageSize = 6;
            var list = _blogService.GetBlogs().Where(p => p.BlogCategoryId == 9 && p.IsAvailable == true).ToPagedList(pageNumb, pageSize);
            var child = _websiteAttribute.GetWebsiteAttributeByName("BannerChild");
            ViewBag.BannerChild = child.LinkUrl;
            return View(list);
        }
      

    }
}

