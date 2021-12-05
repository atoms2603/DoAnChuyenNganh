using System.Web.Mvc;
using System.Collections.Generic;


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

        public ActionResult formThanhToanSach(string id)
        {
            if ((bool)Session["isLogin"] == false) // xét nếu chưa đăng nhập thì phải đăng nhập
            {
                TempData["flagMuaSach"] = id;
                return RedirectToAction("IndexDangNhap", "User");
            }
            if (TempData["flagMaSach"] != null) // lấy mã sách từ Action DangNhap của Controller User
                return View(db.saches.Find(TempData["flagMaSach"] as string));
            return View(db.saches.Find(id));
        }

    }
}