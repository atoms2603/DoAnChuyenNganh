using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class AdminController : Controller
    {
        private Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: Admin
        public ActionResult AdminLogin()
        {
            if (TempData["flagCheckError"] != null)
                ViewBag.flagCheckError = true;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(Models.adminlogin adminlogin)
        {

            if (ModelState.IsValid)
            {
                Models.adminlogin x = db.adminlogins.Find(adminlogin.taikhoan);
                if (x != null)
                {
                    if (x.matkhau == adminlogin.matkhau)
                    {
                        Session["AdminLogin"] = x;
                        Session["AdminCheckLogin"] = true;
                        Session["isLogin"] = true;
                        return RedirectToAction("QuanLySach","Sach");
                    }
                }
                TempData["flagCheckError"] = true;
                return RedirectToAction("AdminLogin");
            }
            return View("AdminLogin");
        }

    }
}