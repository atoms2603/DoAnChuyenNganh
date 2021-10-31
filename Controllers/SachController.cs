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
            ViewBag.dsSach_TL = db.sach_theloai;
            return View(db.saches);
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
        [HttpPost]
        public ActionResult themSach()
        {
            if (ModelState.IsValid)
            {
                string maSach = Request["masach"].ToString();
                string tenSach = Request["tensach"].ToString();
                int namxb = System.Convert.ToInt32(Request["namxuatban"].ToString());
                string maLoai = Request["maloai"].ToString();
                string maNXB = Request["manhaxuatban"].ToString();
                string maTacGia = Request["matg"].ToString();
                decimal gia = System.Convert.ToDecimal(Request["phi"].ToString());

                QLSachOnline.Models.sach_theloai sach_Theloai = new Models.sach_theloai();
                QLSachOnline.Models.sach_tacgia sach_Tacgia = new Models.sach_tacgia();
                QLSachOnline.Models.sach sach = new Models.sach();

                sach.masach = maSach;
                sach.tensach = tenSach;
                sach.namxuatban = namxb;
                sach.phi = gia;
                sach.manhaxuatban = maNXB;

                sach_Theloai.maloai = maLoai;
                sach_Theloai.masach = maSach;

                sach_Tacgia.masach = maSach;
                sach_Tacgia.matg = maTacGia;

                db.saches.Add(sach);
                db.sach_theloai.Add(sach_Theloai);
                db.sach_tacgia.Add(sach_Tacgia);

                db.SaveChanges();
            }
            return RedirectToAction("QuanLySach");
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