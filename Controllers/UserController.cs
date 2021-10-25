using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN.Controllers
{
    //Quản lý người dùng sẽ ở đây
    public class UserController : Controller
    {
        // GET: User
        public ActionResult IndexUser()
        {
            return View();
        }
    }
}