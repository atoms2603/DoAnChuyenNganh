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
            if (TempData["flagRong"] != null)
                ViewBag.flagMaRong = true;
            if(TempData["flagCo"]!=null)
                ViewBag.flagCo = true;
            return View();
        }
        
        [HttpPost]
        public ActionResult themTacGia(Models.tacgia tg)
        {
            string maTG = Request["matg"].ToString().ToUpper();
            if ( maTG == "")
            {
                TempData["flagRong"] = true;
                return RedirectToAction("formThemTacGia");
            }
            else
            {
                if(db.tacgias.Find(maTG)!=null)
                {
                    TempData["flagCo"] = true;
                    return RedirectToAction("formThemTacGia");
                }

                db.tacgias.Add(tg);
                db.SaveChanges();
                return RedirectToAction("QuanLyTacGia");
            }
                
        }
        public ActionResult formXoaTacGia(string id)
        {
            if (db.tacgias.Find(id).saches.Count == 0)
                ViewBag.flagXoa = true;
            return View(db.tacgias.Find(id));
        }
        [HttpPost]
        public ActionResult xoaTacGia(string id)
        {
            QLSachOnline.Models.tacgia tg = db.tacgias.Find(id);
            db.tacgias.Remove(tg);
            db.SaveChanges();
            return RedirectToAction("QuanLyTacGia");
        }
        public ActionResult formChiTietTacGia(String id)
        {
            return View(db.tacgias.Find(id));
        }
        public ActionResult formChinhSuaTG(String id)
        {
            return View(db.tacgias.Find(id));
        }
        
        [HttpPost]
        public ActionResult chinhSuaTG(Models.tacgia x)
        {
            Models.tacgia tg = db.tacgias.Find(x.matg);
            tg.tentg = x.tentg;
            tg.ngaysinh = x.ngaysinh;
            tg.gioitinh = x.gioitinh;
            tg.quequan = x.quequan;
            tg.nghedanh = x.nghedanh;
            db.SaveChanges();
            return RedirectToAction("QuanLyTacGia");
        }
    }
}