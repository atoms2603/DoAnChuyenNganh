using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLSachOnline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            Session["Login"] = new Models.userlogin();
            Session["isLogin"] = false;

            Session["AdminLogin"] = new Models.adminlogin();
            Session["AdminCheckLogin"] = false;
        }
    }
}
