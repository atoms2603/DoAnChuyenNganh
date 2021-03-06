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
        
        [HttpPost]
        public ActionResult themTacGia(Models.tacgia tg)
        {
            if (ModelState.IsValid)
            {
                if (db.tacgias.Find(tg.matg) == null)
                {
                    tg.matg = tg.matg.ToUpper();
                    db.tacgias.Add(tg);
                    db.SaveChanges();
                    return RedirectToAction("QuanLyTacGia");
                }
                ModelState.AddModelError("matg", "Mã trùng vui lòng nhập lại !");
            }
            return View("formThemTacGia");
        }
        public ActionResult formXoaTacGia(string id)
        {
            if (db.tacgias.Find(id).saches.Count == 0)
                ViewBag.flagXoa = true;
            return View(db.tacgias.Find(id));
        }
        
        [HttpPost]
        public ActionResult xoaTacGia()
        { 
            Models.tacgia tg = db.tacgias.Find(Request["matg"].ToString());
            db.tacgias.Remove(tg);
            db.SaveChanges();
            return RedirectToAction("QuanLyTacGia");
        }
        public ActionResult formChiTietTacGia(string id)
        {
            return View(db.tacgias.Find(id));
        }
        public ActionResult formChinhSuaTG(string id)
        {
            return View(db.tacgias.Find(id));
        }
        
        [HttpPost]
        public ActionResult chinhSuaTG(Models.tacgia x)
        {
            if (ModelState.IsValid)
            {
                Models.tacgia tg = db.tacgias.Find(x.matg);
                tg.tentg = x.tentg;
                tg.ngaysinh = x.ngaysinh;
                tg.gioitinh = x.gioitinh;
                tg.quequan = x.quequan;
                tg.nghedanh = x.nghedanh;
            }
            
            db.SaveChanges();
            return RedirectToAction("QuanLyTacGia");
        }
    }
}