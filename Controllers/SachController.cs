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
            ViewBag.dsTacGia = db.tacgias;
            ViewBag.dsNXB = db.nhaxuatbans;
            return View(db.theloais);
        }
        [HttpPost]
        public ActionResult themSach()
        {
            if (ModelState.IsValid)
            {
                string[] dsID_TL = Request.Form.GetValues("maloai");
                string[] dsID_TG = Request.Form.GetValues("matg");

                string maSach = Request["masach"].ToString();
                string tenSach = Request["tensach"].ToString();
                int namxb = System.Convert.ToInt32(Request["namxuatban"].ToString());
                
                string maNXB = Request["manhaxuatban"].ToString();
                
                decimal gia = System.Convert.ToDecimal(Request["phi"].ToString());

                
                
                QLSachOnline.Models.sach sach = new Models.sach();

                sach.masach = maSach;
                sach.tensach = tenSach;
                sach.namxuatban = namxb;
                sach.phi = gia;
                sach.manhaxuatban = maNXB;



                foreach (var item in dsID_TL)
                {
                    QLSachOnline.Models.sach_theloai sach_Theloai = new Models.sach_theloai();
                    sach_Theloai.maloai= item;
                    sach_Theloai.masach = maSach;
                    db.sach_theloai.Add(sach_Theloai);
                }
                foreach (var item in dsID_TG)
                {
                    QLSachOnline.Models.sach_tacgia sach_Tacgia = new Models.sach_tacgia();
                    sach_Tacgia.matg= item;
                    sach_Tacgia.masach = maSach;
                    db.sach_tacgia.Add(sach_Tacgia);
                }

                db.saches.Add(sach);


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