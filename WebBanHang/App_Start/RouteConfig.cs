using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) //trang mặc định chạy trước tiên là “Trang chủ”

        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new
            {
                controller = "Products",
                action = "ProductList",
                id =
           UrlParameter.Optional
            }
            );
        }
    }

}
