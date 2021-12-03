using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class UserController : Controller
    {
        private QLSachOnline.Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: User
        public ActionResult IndexDangNhap()
        {
            if (TempData["flagCheckError"] != null)
                ViewBag.flagCheckError = true;
            if (TempData["flagMuaSach"] != null)
                ViewBag.flagMuaSach = TempData["flagMuaSach"] as string;
            return View();
        }
        public ActionResult IndexDangKy()
        {
            return View();
        }
        public ActionResult ThongTinChiTietUser(string id)
        {
            return View(db.userlogins.Find(id));
        }
        [HttpPost]
        public ActionResult DangKy()
        {
            if (ModelState.IsValid)
            {
                Models.userlogin user = new Models.userlogin();
                string taikhoan = Request["taikhoan"].ToString();
                string matkhau = Request["matkhau"].ToString();
                string sdt = Request["sdt"].ToString();
                string email = Request["email"].ToString();

                user.taikhoan = taikhoan;
                user.matkhau = matkhau;
                user.sdt = sdt;
                user.email = email;

                db.userlogins.Add(user);
                db.SaveChanges();
            }
            return View("~/Views/Home/Index.cshtml",db.saches);
        }
        public ActionResult DangNhap()
        {
            
            if (Request["taikhoan"] == null || Request["matkhau"] == null)
            {
                TempData["flagCheckError"] = true;
                return RedirectToAction("IndexDangNhap");
            }
            else
            {
                string tk = Request["taikhoan"].ToString();
                Models.userlogin x = db.userlogins.Find(tk);
                string mk = Request["matkhau"].ToString();
                if (x != null)
                {
                    if (x.matkhau == mk)
                    {
                        Session["Login"] = x;
                        Session["isLogin"] = true;

                        if (Request["masach"] != null) // lấy mã sách để truyền qua Action formThanhToanSach của Controller Home
                        {
                            TempData["flagMaSach"] = Request["masach"].ToString();
                            return RedirectToAction("formThanhToanSach", "Home");
                        }
                        return View("~/Views/Home/Index.cshtml", db.saches);
                    }
                }
                TempData["flagCheckError"] = true;
                return RedirectToAction("IndexDangNhap");
            }
        }

        public ActionResult logout()
        {
            Session["Login"] = null;
            Session["isLogin"] = false;
            Session["AdminCheckLogin"] = false;
            return RedirectToAction("Index","Home", db.saches);
        }



        //=================================================================================
        //Xử lý thông tin người dùng
        public ActionResult thongTinNguoiDung(string id)
        {
            return View(db.userlogins.Find(id));
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

        public ActionResult baoMatThietLap(string id)
        {
            return View(db.userlogins.Find(id));
        }

        public ActionResult sachYeuThichUser(string id)
        {
            if (TempData["idUser"] != null)
                id = TempData["idUser"] as string;
            Models.userlogin userlogin = db.userlogins.Find(id);
            List<Models.sach> dsSachUser = new List<Models.sach>();
            foreach (var item in db.luusaches)
            {
                if(item.taikhoan==id)
                    dsSachUser.Add(db.saches.Find(item.masach));
            }
            return View(dsSachUser);
        }

        public ActionResult huyYeuThich(string id)
        {
            Models.userlogin userlogin = Session["Login"] as Models.userlogin;
            foreach (var item in db.luusaches)
            {
                if(id==item.masach&&userlogin.taikhoan==item.taikhoan)
                {
                    db.luusaches.Remove(item);
                    break;
                }    
            }
            db.SaveChanges();
            TempData["idUser"] = userlogin.taikhoan;
            return RedirectToAction("sachYeuThichUser");
        }

        public ActionResult lichSuGDUser(string id)
        {
            return View(db.userlogins.Find(id));
        }
    }
}