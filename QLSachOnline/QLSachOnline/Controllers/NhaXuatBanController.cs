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
            return View();
        }
        [HttpPost]
        public ActionResult themNhaXuatBan(Models.nhaxuatban nxb)
        {
            if (ModelState.IsValid)
            {
                if(db.nhaxuatbans.Find(nxb.manhaxuatban) == null) {
                    nxb.manhaxuatban = nxb.manhaxuatban.ToUpper();
                    db.nhaxuatbans.Add(nxb);
                    db.SaveChanges();
                }
                ModelState.AddModelError("manhaxuatban", "Mã trùng, Vui lòng nhập lại !");
            }
            return View("QuanLyNhaXuatBan");
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
        [HttpPost]
        public ActionResult chinhSuaNXB(string id)
        {
            Models.nhaxuatban cnNXB = db.nhaxuatbans.Find(id);
            if(Request["tennhaxuatban"]!=null)
                cnNXB.tennhaxuatban = Request["tennhaxuatban"].ToString();
            if(Request["diachi"]!=null)
                cnNXB.diachi = Request["diachi"].ToString();
            db.SaveChanges();
            return RedirectToAction("QuanLyNhaXuatBan");
        }
    }
}