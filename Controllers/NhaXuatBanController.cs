using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class NhaXuatBanController : Controller
    {
        private QLSachOnline.Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: NhaXuatBan
        public ActionResult QuanLyNhaXuatBan()
        {
            return View(db.nhaxuatbans);
        }
        [HttpPost]
        public ActionResult themNhaXuatBan(Models.nhaxuatban nxb)
        {
            if (ModelState.IsValid)
            {
                db.nhaxuatbans.Add(nxb);
                db.SaveChanges();
            }
            return RedirectToAction("QuanLyNhaXuatBan");
        }
        public ActionResult xoaNhaXuatBan(string id)
        {
            if (db.nhaxuatbans.Find(id).saches.Count == 0)
                ViewBag.flagXoa = true;
            return View(db.nhaxuatbans.Find(id));
        }

        [HttpPost]
        public ActionResult xoaNXB(string id)
        {
            Models.nhaxuatban nxb = db.nhaxuatbans.Find(id);
            if (nxb != null)
            {
                db.nhaxuatbans.Remove(nxb);
                db.SaveChanges();
            }
            return RedirectToAction("QuanLyNhaXuatBan");
        }
        public ActionResult chinhSuaNhaXB(string id)
        {
            return View(db.nhaxuatbans.Find(id));
        }
        [HttpPost]
        public ActionResult chinhSuaNXB(string id)
        {
            Models.nhaxuatban cnNXB = db.nhaxuatbans.Find(id);
            cnNXB.tennhaxuatban = Request["tennhaxuatban"].ToString();
            cnNXB.diachi = Request["diachi"].ToString();
            db.SaveChanges();
            return RedirectToAction("QuanLyNhaXuatBan");
        }
    }
}