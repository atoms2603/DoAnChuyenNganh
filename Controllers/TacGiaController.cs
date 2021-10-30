using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class TacGiaController : Controller
    {
        private Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: TacGia
        public ActionResult QuanLyTacGia()
        {
            return View(db.tacgias);
        }
        public ActionResult formThemTacGia()
        {
            return View();
        }
        public ActionResult formXoaTacGia(String id)
        {
            return View(db.tacgias.Find(id));
        }
        public ActionResult formChiTietTacGia(String id)
        {
            return View(db.tacgias.Find(id));
        }
        public ActionResult formChinhSuaTG(String id)
        {
            return View(db.tacgias.Find(id));
        }
    }
}