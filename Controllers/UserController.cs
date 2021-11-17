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
            ViewBag.isLogin = null;
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
            string taikhoan = Request["taikhoan"].ToString();
            Models.userlogin x = db.userlogins.Find(taikhoan);
            string mk = Request["matkhau"].ToString();
            if (x != null)
            {
                if (x.matkhau == mk)
                {
                    Session["Login"] = x;
                    Session["isLogin"] = true;
                    return View("~/Views/Home/Index.cshtml", db.saches);
                }
                else {
                    Session["isLogin"] = false;
                    return View("~/Views/Home/Index.cshtml", db.saches); 
                }
            }
            else
            {
                Session["isLogin"] = false;
                return View("~/Views/Home/Index.cshtml", db.saches);
            }
            
        }
        public ActionResult logout()
        {
            Session["isLogin"] = false;
            return View("~/Views/Home/Index.cshtml", db.saches);
        }
    }
}