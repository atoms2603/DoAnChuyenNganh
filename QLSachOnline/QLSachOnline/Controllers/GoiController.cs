using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class GoiController : Controller
    {
        QLSachOnline.Models.QLySachOnline db = new Models.QLySachOnline();
        // phần hiển thị bên user
        public ActionResult IndexGoi(string id)
        {
            // id ở đây là mã sách từ indexSach truyền qua
            if (id != null)
            {
                Session.Add("flagMaSach", id);
            }
            return View(db.gois.ToList());
        }

        public ActionResult chiTietGoi(string id)
        {
            if (TempData["flagBackGoi"] != null)
                id = TempData["flagBackGoi"] as string;
            return View(db.gois.Find(id));
        }

        // Phần thanh toán
        public ActionResult thanhToanGoi(string id)
        {
            if ((bool)Session["isLogin"])
            {
                Models.goi goi = db.gois.Find(id);
                Models.userlogin userlogin = Session["Login"] as Models.userlogin;
                Models.usergoi usergoi = new Models.usergoi();
                usergoi.magoi = id;
                usergoi.taikhoan = userlogin.taikhoan;
                usergoi.ngaymua = System.DateTime.Now;
                usergoi.ngayhethan = System.DateTime.Now.AddDays(goi.thoihan);

                db.usergois.Add(usergoi);
                db.SaveChanges();

                Session["Login"] = db.userlogins.Find(userlogin.taikhoan);
                userlogin = Session["Login"] as Models.userlogin;
                Session["isHavingPremium"] = true;
                double tongNgay = 0;
                double tongGio = 0;
                double tongPhut = 0;
                foreach (var item in userlogin.usergois.Where(a => a.ngayhethan >= System.DateTime.Now).ToList())
                {
                    tongNgay += (item.ngayhethan - System.DateTime.Now).TotalDays;
                    tongGio += (item.ngayhethan - System.DateTime.Now).TotalHours;
                    tongPhut += (item.ngayhethan - System.DateTime.Now).TotalMinutes;
                }
                Session["PDays"] = (int)Math.Floor(tongNgay);
                if ((int)Session["PDays"] != 0)
                    Session["PHours"] = DateTime.FromOADate(tongNgay - Math.Floor(tongNgay)).Hour;
                else
                    Session["PHours"] = (int)Math.Floor(tongGio);
                if ((int)Session["PHours"] != 0)
                    Session["PMinutes"] = DateTime.FromOADate(tongGio - Math.Floor(tongGio)).Minute;
                else Session["PMinutes"] = (int)Math.Floor(tongPhut);

                if (Session["flagMaSach"] != null)
                    return RedirectToAction("indexSach", "Sach");
                return RedirectToAction("Index","Home");
            }
            TempData["flagBackGoi"] = id;
            return RedirectToAction("IndexDangNhap","User");
        }

        //Phần bên admin
        public ActionResult QuanLyGoi()
        {
            return View(db.gois.ToList());
        }

        public ActionResult formThemGoi()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult themGoi(Models.goi goi)
        {
            if (ModelState.IsValid)
            {
                if (db.gois.Find(goi.magoi) == null)
                {
                    db.gois.Add(goi);
                    db.SaveChanges();
                    return RedirectToAction("QuanLyGoi");
                }
                ModelState.AddModelError("magoi", "Mã trùng ! Vui lòng nhập mã khác !");
            }
            return View("formThemGoi");
        }

        public ActionResult formSuaGoi(string id)
        {
            return View(db.gois.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult suaGoi(Models.goi goi)
        {
            if (ModelState.IsValid)
            {
                Models.goi goiSua = db.gois.Find(goi.magoi);
                if ( goiSua != null)
                {
                    goiSua.tengoi = goi.tengoi;
                    goiSua.motagoi = goi.motagoi;
                    goiSua.thoihan = goi.thoihan;
                    //giá
                    db.SaveChanges();
                }    
            }
            return RedirectToAction("QuanLyGoi");
        }
        public ActionResult formXoaGoi(string id)
        {
            Models.goi goi = db.gois.Find(id);
            if (goi.usergois.Count == 0)
                ViewBag.flagCheck = true;
            return View(db.gois.Find(id));
        }


    }
}