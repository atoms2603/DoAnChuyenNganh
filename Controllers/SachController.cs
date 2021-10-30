using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class SachController : Controller
    {
        private QLSachOnline.Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: Sach
        public ActionResult QuanLySach()
        {
            ViewBag.dsSach_TG = db.sach_tacgia;
            return View(db.sach_theloai);
        }
        public ActionResult formThongTinChiTiet(string id)
        {
            ViewBag.dsSach_TL = db.sach_theloai;
            ViewBag.dsSach_TG = db.sach_tacgia;
            return View(db.saches.Find(id));
        }
        public ActionResult indexSach(string id)
        {
            ViewBag.dsSach_TL = db.sach_theloai;
            ViewBag.dsSach_TG = db.sach_tacgia;
            return View(db.saches.Find(id));
        }

        public ActionResult formThemSach()
        {
            ViewBag.dsSach_TG = db.sach_tacgia;
            ViewBag.dsNXB = db.nhaxuatbans;
            return View(db.sach_theloai);
        }
        public ActionResult formChinhSua(string id)
        {
            ViewBag.dsSach_TG = db.sach_tacgia;
            ViewBag.dsNXB = db.nhaxuatbans;
            ViewBag.dsSach_TL = db.sach_theloai;
            return View(db.saches.Find(id));
        }
        public ActionResult formXoaSach(string id)
        {
            ViewBag.dsSach_TL = db.sach_theloai;
            ViewBag.dsSach_TG = db.sach_tacgia;
            return View(db.saches.Find(id));
        }
    }
}