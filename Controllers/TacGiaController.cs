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
        public ActionResult themTacGia(QLSachOnline.Models.tacgia tg)
        {
            if (ModelState.IsValid)
            {
                db.tacgias.Add(tg);
                db.SaveChanges();
            }
            return RedirectToAction("QuanLyTacGia");
        }
        public ActionResult formXoaTacGia(String id)
        {
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
        public ActionResult chinhSuaTG(string id)
        {
            QLSachOnline.Models.tacgia tg = db.tacgias.Find(id);
            tg.tentg = Request["tentg"].ToString();
            tg.ngaysinh = System.Convert.ToDateTime(Request["ngaysinh"].ToString());
            tg.gioitinh = System.Convert.ToBoolean(Request["gioitinh"].ToString());
            tg.quequan = Request["quequan"].ToString();
            tg.nghedanh = Request["nghedanh"].ToString();

            db.SaveChanges();


            return RedirectToAction("QuanLyTacGia");
        }
    }
}