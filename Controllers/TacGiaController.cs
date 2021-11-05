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
        public ActionResult themTacGia()
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

                QLSachOnline.Models.tacgia tg = new Models.tacgia();
                tg.matg = maTG;
                tg.tentg = Request["tentg"].ToString();
                if (Request["ngaysinh"].ToString() != "")
                    tg.ngaysinh = System.Convert.ToDateTime(Request["ngaysinh"].ToString());
                else tg.ngaysinh = null;
                tg.gioitinh = System.Convert.ToBoolean(Request["gioitinh"]);
                tg.quequan = Request["quequan"].ToString();
                tg.nghedanh = Request["nghedanh"].ToString();

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