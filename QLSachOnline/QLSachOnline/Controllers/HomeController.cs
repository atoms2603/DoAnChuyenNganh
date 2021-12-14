using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace QLSachOnline.Controllers
{
    public class HomeController : Controller
    {
        private QLSachOnline.Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.saches);
        }

        public ActionResult formTheLoaiFilter(string id)
        {
            List<Models.sach> dsSach = new List<Models.sach>();
            Models.theloai tl = db.theloais.Find(id);
            foreach (var item in tl.saches)
            {
                dsSach.Add(item);
            }
            ViewBag.tenTheLoai = tl.tentl;
            return View(dsSach);
        }

        public ActionResult formGopY()
        {
            return View();
        }

        public ActionResult chonPhuongThucThanhToan(string id)
        {
            //id này của Gói
            ViewBag.idGoi = id;
            if (!(bool)Session["isLogin"])
                return RedirectToAction("IndexDangNhap", "User");
            return View();
        }

        //refresh TIME
        public ActionResult refreshTimer()
        {
            string timer = "";
            Models.userlogin x = Session["Login"] as Models.userlogin;//lấy ID tài khoản

            //cập nhật lại giá trị (trường hợp vừa thanh toán xong gói khác)
            x = db.userlogins.Find(x.taikhoan);
            Session["Login"]= db.userlogins.Find(x.taikhoan);
            //====

            double tongNgay = (x.usergois.ToArray()[x.usergois.Count - 1].ngayhethan - System.DateTime.Now).TotalDays;
            Session["PDays"] = (int)Math.Floor(tongNgay);
            Session["PHours"] = DateTime.FromOADate(tongNgay - Math.Floor(tongNgay)).Hour;
            Session["PMinutes"] = DateTime.FromOADate(tongNgay - Math.Floor(tongNgay)).Minute;
            timer = (int)Session["PDays"] + " Ngày " + (int)Session["PHours"] + " Giờ " + (int)Session["PMinutes"] + " Phút";
            return Json(timer,JsonRequestBehavior.AllowGet);
        }

    }
}