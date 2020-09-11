using Labixa.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Labixa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("culture", "language/{slug}", new { controller = "Home", action = "SetCulture", slug = UrlParameter.Optional });
            routes.MapRoute("news", "news", new { controller = "New", action = "News" });
            routes.MapRoute("newsdetail", "newDetail/{slug}", new { controller = "New", action = "NewsDetail" });

            routes.MapRoute("product", "product", new { controller = "Products", action = "Products" });
            routes.MapRoute("productdetail", "productDetail/{slug}", new { controller = "Products", action = "ProductDetail" });
                  
            routes.MapRoute("aboutus", "aboutus", new { controller = "Home", action = "AboutUs" });
            routes.MapRoute("contact", "contact", new { controller = "Home", action = "Contact" });

            routes.MapRoute("cart", "cart", new { controller = "Cart", action = "Index" });
            routes.MapRoute("checkout", "checkout", new { controller = "Cart", action = "Checkout" });

            routes.MapRoute("detailcart", "detailCart", new { controller = "Products", action = "DetailCart" });
            routes.MapRoute("cartpay", "cartPay", new { controller = "Products", action = "CartPays" });
            ///
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }


    }
}
