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
        public ActionResult formThemSach()
        {
            ViewBag.dsTheLoai = db.theloais.ToList();
            ViewBag.dsTacGia = db.tacgias.ToList();
            ViewBag.dsNhaXuatBan = db.nhaxuatbans.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult themSach(Models.sach s)
        {
            if (ModelState.IsValid)
            {
                db.saches.Add(s);
                db.SaveChanges();
            }
            return RedirectToAction("formQuanLySach");
        }

        public ActionResult formXoaSach()
        {
            return View(db.saches.ToList());
        }
        public ActionResult formQuyetDinhXoa(string id)
        {
            Models.sach s = db.saches.Find(id);
            return View(s);
        }
        public ActionResult xoaSach(string id)
        {
            Models.sach s = db.saches.Find(id);
            db.saches.Remove(s);
            db.SaveChanges();
            return RedirectToAction("formQuanLySach");
        }
    }
}