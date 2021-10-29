using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class TacGiaController : Controller
    {
        // GET: TacGia
        public ActionResult QuanLyTacGia()
        {
            return View();
        }
        public ActionResult formThemTacGia()
        {
            return View();
        }
        public ActionResult formXoaTacGia()
        {
            return View();
        }
        public ActionResult formChiTietTacGia()
        {
            return View();
        }
        public ActionResult formChinhSuaTG()
        {
            return View();
        }
    }
}