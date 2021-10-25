using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN.Controllers
{
    //Quản lý các thông báo sẽ ở đây.
    public class ThongBaoController : Controller
    {
        // GET: ThongBao
        public ActionResult IndexThongBao()
        {
            return View();
        }
    }
}