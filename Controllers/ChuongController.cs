using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class ChuongController : Controller
    {
        QLSachOnline.Models.QLySachOnline db = new Models.QLySachOnline();

        // GET: Chuong

        [HttpPost]
        public ActionResult themChuong(Models.chuong ch)
        {
            Models.sach s = db.saches.Find(ch.masach);
            if (!s.chuongs.Contains(ch))
            {
                s.chuongs.Add(ch);
                db.SaveChanges();
            }
            TempData["chuongSach"] = s;
            return RedirectToAction("formThongTinChiTiet", "Sach");
        }

        [HttpPost]
        public ActionResult xoaChuong(string id)
        {
            Models.sach s = db.saches.Find(id);
            foreach (var item in db.chuongs)
            {
                if (item.masach == id && item.machuong == Request["machuong"].ToString())
                {
                    db.chuongs.Remove(item);
                    break;
                }
            }
            TempData["chuongSach"] = s; //biến tạm để lưu trữ khi RedirectToAction 
            db.SaveChanges();
            return RedirectToAction("formThongTinChiTiet", "Sach");
        }
        public ActionResult chinhSuaChuong()
        {
            Models.sach s = db.saches.Find(Request["masach"].ToString());
            foreach (var item in db.chuongs)
            {
                if (item.masach == Request["masach"].ToString() && item.machuong == Request["machuong"].ToString())
                {
                    item.tenchuong = Request["tenchuong"].ToString();
                    item.noidung = Request["noidung"].ToString();
                    break;
                }
            }
            TempData["chuongSach"] = s;
            db.SaveChanges();
            return RedirectToAction("formThongTinChiTiet", "Sach");
        }
    }
}