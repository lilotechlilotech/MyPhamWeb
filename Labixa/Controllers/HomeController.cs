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
using System.Text.RegularExpressions;

namespace Labixa.Controllers
{

    public class HomeController : BaseHomeController
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productcategoryService;
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IWebsiteAttributeService _websiteAttributeService;
        private readonly IStaffService _staffService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductRelationshipService _productRelationshipService;



        public HomeController(IProductService productService, IBlogService blogService,
            IWebsiteAttributeService websiteAttributeService, IBlogCategoryService blogCategoryService,
            IStaffService staffService, IProductAttributeMappingService productAttributeMappingService,
            IProductRelationshipService productRelationshipService, IProductCategoryService productcategoryService)
        {
            this._productService = productService;
            this._blogService = blogService;
            this._websiteAttributeService = websiteAttributeService;
            this._blogCategoryService = blogCategoryService;
            this._staffService = staffService;
            this._productAttributeMappingService = productAttributeMappingService;
            this._productRelationshipService = productRelationshipService;
            this._productcategoryService = productcategoryService;
        }
        public ActionResult Index()
        {
            var model = _productService.GetAllProducts().OrderByDescending(x => x.DateCreated).Where(p => p.IsPublic == true);
            // ViewBag.banner01 = _websiteAttributeService.GetWebsiteAttributeById(5).LinkUrl;
            //HomeViewModels model = new HomeViewModels();
            //model.logo = _websiteAttributeService.GetWebsiteAttributeByName("logo") ;

            return View(model);

        }

        public ActionResult getMission()
        {

            return PartialView("_Mission");
        }
        public ActionResult getContact()
        {

            return PartialView("_ContactForm");
        }

        public ActionResult getMission()
        {
          
            return PartialView("_Mission");
        }
        public ActionResult getHeader()
        {
            //var websiteAttribute = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Type.ToLower().Equals("social")).ToList();
            //ViewBag.social = websiteAttribute;
            //var list = _productcategoryService.GetProductCategories();
            ////HomeViewModels model = new HomeViewModels();
            ////model.logo = _websiteAttributeService.GetWebsiteAttributeByName("logo");
            //var logo = _websiteAttributeService.GetWebsiteAttributeByName("logo");
            //ViewBag.logobig = logo.LinkUrl;
            //ViewBag.logosmall = logo.Noted_1;
            //return PartialView("_Header",list);
            return PartialView("_Header");
        }
        public ActionResult Banner()
        {
            var model = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Type.Equals("Banner")).ToList();
            return PartialView("_BannerHome", model);
        }
        public ActionResult zalo()
        {
            var model = _websiteAttributeService.GetWebsiteAttributeById(14);
            return PartialView("_zalo", model);
        }

        public ActionResult getFooter()
        {
            //var websiteAttribute = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Type.ToLower().Equals("social")).ToList();
            //ViewBag.social = websiteAttribute;
            ////HomeViewModels model = new HomeViewModels();
            ////model.logo = _websiteAttributeService.GetWebsiteAttributeByName("logo");
            //var logo = _websiteAttributeService.GetWebsiteAttributeByName("logo");
            //ViewBag.logobig = logo.LinkUrl;

            return PartialView("_Footer");
        }
        public ActionResult AboutUs()
        {
            ViewBag.returnUrl = "AboutUs";
            var us = _websiteAttributeService.GetWebsiteAttributeByName("about");
            var child = _websiteAttributeService.GetWebsiteAttributeByName("BannerChild");
            ViewBag.BannerChild = child.LinkUrl;
            return View(model: us);
        }

        public ActionResult getProductCategory()
        {
            var list = _productcategoryService.GetProductCategories().Where(p => p.Position == 21 && p.Id != 21).ToList();
            return PartialView("_ProductCategory", list);
        }
        public ActionResult getVisionHome()
        {
            var vision = _websiteAttributeService.GetWebsiteAttributeByName("vision");
            return PartialView("_VisionHome", vision);
        }
        public ActionResult getValueHome()
        {
            var value = _websiteAttributeService.GetWebsiteAttributeByName("coreValue");
            return PartialView("_ValueHome", value);
        }
        public ActionResult getMisionHome()
        {
            var mision = _websiteAttributeService.GetWebsiteAttributeByName("mision");
            return PartialView("_MisionHome", mision);
        }
        public ActionResult getBannerHome()
        {
            var banner = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Type == "Banner");
            return PartialView("_BannerHome", banner);
        }
        public ActionResult cartIndex()
        {
            return PartialView("_cartIndex");
        }



        public ActionResult Contact()
        {
            var child = _websiteAttributeService.GetWebsiteAttributeByName("BannerChild");
            ViewBag.BannerChild = child.LinkUrl;
            return View();
        }

        public ActionResult getProductsHome()
        {

            var model = _productService.GetProductHomes().ToList();
            return PartialView("_HomeProducts", model);
        }
        public ActionResult getBlogHome()
        {
            var model = _blogService.GetNewPost().Where(p => p.Deleted == false && p.IsAvailable == true).ToList();
            return PartialView("_HomeBlog", model);
        }
        #region[Multi Language]

        public ActionResult SetCulture(string slug)
        {
            //SetCultu(slug);
            //return RedirectToAction("Index", "Home");
            slug = CultureHelper.GetImplementedCulture(slug);
            HttpCookie cookie = Request.Cookies["_culture"];
            if (slug == null)
            {
                slug = "vi";
            }
            if (cookie != null)
            {
                cookie.Value = slug;
                // cookie.Expires = DateTime.Now.AddYears(1);
                //Response.SetCookie(cookie);
            }
            else
            {
                cookie = new HttpCookie("_culture")
                {
                    Value = slug,
                    Expires = DateTime.Now.AddYears(1)
                };
            }
            Response.Cookies.Set(cookie);
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region form submit
        [HttpPost]
        public ActionResult formContact(FormCollection formData)
        {
            var name = formData["name"];
            var email = formData["email"];
            var message = formData["message"];
            var phone = formData["phone"];
            Staff staf = new Staff()
            {
                Phone = phone,
                Name = name,
                Yahoo = email,
                Description = message,
                Deleted = false
            };
            _staffService.CreateStaff(staf);
            ViewBag.response = "Xin cảm ơn, Mọi thông tin đã được lưu trữ";
            return View("Contact");
            //return RedirectToAction("contact", "Home");
        }
        #endregion
        public class infomationContact
        {
            public string name { get; set; }
            public string email { get; set; }
            public string message { get; set; }
        }



    }
}

