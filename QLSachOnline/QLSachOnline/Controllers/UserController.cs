using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class UserController : Controller
    {
        QLSachOnline.Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: User
        public ActionResult IndexDangNhap()
        {
            if (TempData["flagErrorMK"] != null) ViewBag.flagErrorMK = true;
            if (TempData["flagUnknownTK"] != null) ViewBag.flagUnknownTK = true;
            if (TempData["flagMuaSach"] != null) ViewBag.flagMuaSach = TempData["flagMuaSach"] as string;
            if(TempData["flagCheckStatus"] != null) ViewBag.flagCheckStatus = true;
            if (TempData["dangKySuccess"] != null) ViewBag.dangKySuccess = true;

            return View();
        }
        public ActionResult IndexDangKy()
        {
            return View();
        }
        public ActionResult ThongTinChiTietUser()
        {
            return View(Session["Login"] as Models.userlogin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(Models.userlogin userlogin)
        {
            if (ModelState.IsValid)
            {
                if (db.userlogins.Find(userlogin.taikhoan) == null)
                {
                    userlogin.status = true;
                    db.userlogins.Add(userlogin);
                    db.SaveChanges();
                    TempData["dangKySuccess"] = true;
                    return RedirectToAction("IndexDangNhap");
                }
                ModelState.AddModelError("taikhoan", "Tài khoản đã tồn tại !");
            }
            return View("IndexDangKy");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(Models.userlogin userlogin)
        {
            if (ModelState.IsValid)
            {
                Models.userlogin x = db.userlogins.Find(userlogin.taikhoan);
                if (x != null)
                {
                    if (x.matkhau == userlogin.matkhau)
                    {
                        if (x.status.Equals(true)) 
                        { 
                            Session["Login"] = x;
                            Session["isLogin"] = true;

                            if (Request["masach"] != null) // lấy mã sách để truyền qua Action formThanhToanSach của Controller Home
                            {
                                TempData["flagMaSach"] = Request["masach"].ToString();
                                return RedirectToAction("formThanhToanSach", "Home");
                            }
                            return RedirectToAction("Index", "Home");
                        }
                        else TempData["flagCheckStatus"] = true;
                    }
                    else TempData["flagErrorMK"] = true;
                }
                else TempData["flagUnknownTK"] = true;

                return RedirectToAction("IndexDangNhap");
            }
            return View("IndexDangNhap");
        }

        public ActionResult logout()
        {
            Session["Login"] = null;
            Session["isLogin"] = false;
            Session["AdminCheckLogin"] = false;
            return RedirectToAction("Index","Home");
        }



        //=================================================================================
        //Xử lý thông tin người dùng
        public ActionResult thongTinNguoiDung()
        {
            return View(Session["Login"] as Models.userlogin);
        }

        [HttpPost]
        public ActionResult capNhatThongTin(Models.userlogin usr)
        {
            Models.userlogin userlogin = db.userlogins.Find(usr.taikhoan);
            if (Request["matkau"] != null) userlogin.matkhau = usr.matkhau;
            if (Request["sdt"] != null) userlogin.sdt = usr.sdt;
            if (Request["email"] != null) userlogin.email = usr.email;
            db.SaveChanges();
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult baoMatThietLap()
        {
            return View(Session["Login"] as Models.userlogin);
        }

        public ActionResult sachYeuThichUser()
        {
            Models.userlogin userlogin = Session["Login"] as Models.userlogin;
            List<Models.sach> dsSachUser = new List<Models.sach>();
            foreach (var item in db.luusaches)
            {
                if(item.taikhoan==userlogin.taikhoan)
                    dsSachUser.Add(db.saches.Find(item.masach));
            }
            return View(dsSachUser);
        }

        public ActionResult huyYeuThich(string id)
        {
            Models.userlogin userlogin = Session["Login"] as Models.userlogin;
            db.luusaches.Remove(db.luusaches.Where(x => x.masach == id).Where(x=>x.taikhoan==userlogin.taikhoan).First());
            db.SaveChanges();
            Session["Login"] = db.userlogins.Find(userlogin.taikhoan);
            return RedirectToAction("sachYeuThichUser");
        }

        public ActionResult lichSuGDUser()
        {
            return View(Session["Login"] as Models.userlogin);
        }
        public ActionResult quanLyUser()
        {
            return View(db.userlogins);
        }
        public ActionResult xulyStatus(string id)
        {
            int result = 1;
            Models.userlogin x = db.userlogins.Find(id);
            if (x.status.Value)
            {
                result = 0;
                x.status = false;
            }
            else x.status = true;
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


   
    }
}