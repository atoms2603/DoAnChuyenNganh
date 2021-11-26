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
                        return View("~/Views/Home/Index.cshtml", db.saches);
                    }
                }
                TempData["flagCheckError"] = true;
                return RedirectToAction("IndexDangNhap");
            }
        }

        public ActionResult logout()
        {
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

        public ActionResult baoMatThietLap(string id)
        {
            return View(db.userlogins.Find(id));
        }

        public ActionResult sachYeuThichUser(string id)
        {
            Models.userlogin userlogin = db.userlogins.Find(id);
            List<Models.sach> dsSachUser = new List<Models.sach>();
            foreach (var item in userlogin.luusaches)
            {
                dsSachUser.Add(db.saches.Find(item.masach));
            }
            return View(dsSachUser);
        }

        public ActionResult lichSuGDUser(string id)
        {
            return View(db.userlogins.Find(id));
        }
    }
}