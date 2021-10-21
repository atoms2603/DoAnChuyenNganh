using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN.Controllers
{
    public class HomeController : Controller
    {
        private Models.ModelQLSach db = new Models.ModelQLSach();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult formQuanLySach()
        {
            return View(db.saches.ToList());
        }
    }
}