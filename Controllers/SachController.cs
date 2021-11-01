using System.Web.Mvc;
using System.Linq;


namespace QLSachOnline.Controllers
{
    public class SachController : Controller
    {
        private QLSachOnline.Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: Sach
        public ActionResult QuanLySach()
        {
            ViewBag.dsTG = db.tacgias;
            ViewBag.dsTL = db.theloais;
            return View(db.saches);
        }
        public ActionResult formThongTinChiTiet(string id)
        {
            ViewBag.dsTG = db.tacgias;
            ViewBag.dsTL = db.theloais;
            return View(db.saches.Find(id));
        }
        public ActionResult indexSach(string id)
        {
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
                    foreach (var item2 in db.theloais)
                    {
                        if (item.Equals(item2.maloai))
                            sach.theloai.Add(item2);
                    }
                }
               
                    
                foreach (var item in dsID_TG)
                {
                    foreach (var item2 in db.tacgias)
                    {
                        if (item.Equals(item2.matg))
                            sach.tacgia.Add(item2);
                    }
                }

                db.saches.Add(sach);


                db.SaveChanges();
            }
            return RedirectToAction("QuanLySach");
        }
        public ActionResult formChinhSua(string id)
        {
            ViewBag.dsTG = db.tacgias;
            ViewBag.dsTL = db.theloais;
            ViewBag.dsNXB = db.nhaxuatbans;
            return View(db.saches.Find(id));
        }
        [HttpPost]
        public ActionResult ChinhSuaSach(Models.sach sach)
        {
            if (ModelState.IsValid)
            {
                Models.sach sachsua = db.saches.Find(sach.masach);

                sachsua.tensach = sach.tensach;
                sachsua.namxuatban = sach.namxuatban;
                sachsua.phi = sach.phi;
                sachsua.manhaxuatban = sach.manhaxuatban;
                sachsua.theloai = sach.theloai;
                sachsua.tacgia = sach.tacgia;
                sachsua.tomtat = sach.tomtat;
                sachsua.giaodich = sach.giaodich;
                sachsua.hinhanh = sach.hinhanh;
                sachsua.chuong = sach.chuong;
                sachsua.luusach = sach.luusach;

                db.SaveChanges();
            }
            return RedirectToAction("QuanLySach");
        }
        public ActionResult formXoaSach(string id)
        {
            ViewBag.dsTG = db.tacgias;
            ViewBag.dsTL = db.theloais;
            Models.sach x = db.saches.Find(id);
            if (x != null)
            {
                int count = db.luusachs.Where(t => t.masach == id).ToList().Count;
                if (count <= 0) ViewBag.flagXoa = true;
                else ViewBag.flagXoa = false;
                return View(x);
            }
            return View(db.saches.Find(id));
        }
        public ActionResult xoaSach(string id)
        {
            Models.sach sach = db.saches.Find(id);
            sach.tacgia.Clear();
            sach.theloai.Clear();
            db.saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("QuanLySach");
        }
    }
}