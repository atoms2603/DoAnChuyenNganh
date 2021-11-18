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
        public ActionResult DangNhap()
        {

            if (Request["taikhoan"] == null || Request["matkhau"] == null)
            {
                TempData["flagCheckError"] = true;
                return RedirectToAction("AdminLogin");
            }
            else
            {
                string tk = Request["taikhoan"].ToString();
                Models.adminlogin x = db.adminlogins.Find(tk);
                string mk = Request["matkhau"].ToString();
                if (x != null)
                {
                    if (x.matkhau == mk)
                    {
                        Session["AdminLogin"] = x;
                        Session["isAdminLogin"] = true;
                        return RedirectToAction("QuanLySach","Sach");
                    }
                }
                TempData["flagCheckError"] = true;
                return RedirectToAction("AdminLogin");
            }
        }
        public ActionResult logout()
        {
            Session["isAdminLogin"] = false;
            return View("~/Views/Home/Index.cshtml", db.saches);
        }
    }
}