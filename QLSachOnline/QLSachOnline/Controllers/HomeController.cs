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
            if (id.Equals("free"))
            {
                dsSach.AddRange(db.saches.Where(x => !x.premium).ToList());
                ViewBag.tenTheLoai = "Free";
            }
            else if(id.Equals("premium"))
            {
                dsSach.AddRange(db.saches.Where(x => x.premium).ToList());
                ViewBag.tenTheLoai = "Premium";
            }
            else
            {
                dsSach.AddRange(db.theloais.Find(id).saches.ToList());
                ViewBag.tenTheLoai = db.theloais.Find(id).tentl;
            }
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

        //XỬ LÝ THÔNG TIN SÁCH
        public ActionResult formSearchResult()
        {
            List<Models.sach> dsSach = Session["dsSach"] as List<Models.sach>;
            Session.Remove("dsSach");
            return View(dsSach);
        }

        public ActionResult searchSach(string id)
        {
            int i = 0;
            if (id != null)
            {
                List<Models.sach> dsSach = new List<Models.sach>();
                dsSach.AddRange(db.saches.Where(x => x.tensach.ToLower().Contains(id)).ToList());
                Session.Add("dsSach", dsSach);
                i = 1;
            }
            return Json(i, JsonRequestBehavior.AllowGet);
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