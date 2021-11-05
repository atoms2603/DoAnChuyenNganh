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
            return View();
        }
        public ActionResult IndexDangKy()
        {
            return View();
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
        [HttpGet]
        public ActionResult DangNhap()
        {
            string taikhoan = Request["taikhoan"].ToString();
            Models.userlogin x = db.userlogins.Find(taikhoan);
            string mk = Request["matkhau"].ToString();
            if (x != null)
            {
                if(x.matkhau == mk)
                    return View("~/Views/User/DangNhapThanhCong.cshtml");
                else return View("~/Views/Home/Index.cshtml", db.saches);
            }
            else
            {
                return View("~/Views/Home/Index.cshtml", db.saches);
            }
            
        }
    }
}