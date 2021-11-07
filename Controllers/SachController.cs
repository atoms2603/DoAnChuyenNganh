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
            if (TempData["chuongSach"] != null)
            {
                if (TempData["trungMa"] != null)
                    ViewBag.flagCo = true;
                if (TempData["maRong"] != null)
                    ViewBag.flagMaRong = true;
                return View(TempData["chuongSach"] as Models.sach);
            }
            return View(db.saches.Find(id));
        }
        public ActionResult indexSach(string id)
        {
            return View(db.saches.Find(id));
        }

        public ActionResult formThemSach()
        {
            if (System.Convert.ToBoolean(TempData["flagCo"]))
                ViewBag.flagCo = true;
            if (TempData["flagRong"]!=null)
                ViewBag.flagMaRong = true;
            return View();
        }
        [HttpPost]
        public ActionResult themSach()
        {
            if (ModelState.IsValid)
            {
                string[] dsID_TL = Request.Form.GetValues("maloai");
                string[] dsID_TG = Request.Form.GetValues("matg");

                if (Request["masach"].ToString() == "") {
                    TempData["flagRong"] = "marong";
                    return RedirectToAction("formThemSach");
                }
                string maSach = Request["masach"].ToString().ToUpper();
                string tenSach = Request["tensach"].ToString();

                

                if (db.saches.Find(maSach)==null)
                {
                    QLSachOnline.Models.sach sach = new Models.sach();
                    string maNXB = Request["manhaxuatban"].ToString();
                    if (Request["namxuatban"].ToString() != "")
                    {
                        int namxb = System.Convert.ToInt32(Request["namxuatban"].ToString());
                        sach.namxuatban = namxb;
                    }
                    if (Request["phi"].ToString() != "")
                    {
                        decimal gia = System.Convert.ToDecimal(Request["phi"].ToString());
                        sach.phi = gia;
                    }
                    sach.masach = maSach.ToUpper();
                    sach.tensach = tenSach;
                    sach.manhaxuatban = maNXB;

                
                    if(dsID_TL!=null)
                        foreach (var item in dsID_TL)
                        {
                            foreach (var item2 in db.theloais)
                            {
                                if (item.Equals(item2.maloai))
                                    sach.theloais.Add(item2);
                            }
                        }
               
                    if(dsID_TG!=null)
                        foreach (var item in dsID_TG)
                        {
                            foreach (var item2 in db.tacgias)
                            {
                                if (item.Equals(item2.matg))
                                    sach.tacgias.Add(item2);
                            }
                        }

                    db.saches.Add(sach);


                    db.SaveChanges();
                }
                else
                {
                    TempData["flagCo"] = true;
                    return RedirectToAction("formThemSach");
                }
            }
            return RedirectToAction("QuanLySach");
        }
        public ActionResult formChinhSua(string id)
        {
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
                sachsua.theloais = sach.theloais;
                sachsua.tacgias = sach.tacgias;
                sachsua.tomtat = sach.tomtat;
                sachsua.giaodiches = sach.giaodiches;
                sachsua.hinhanh = sach.hinhanh;
                sachsua.chuongs = sach.chuongs;
                sachsua.luusaches = sach.luusaches;

                db.SaveChanges();
            }
            return RedirectToAction("QuanLySach");
        }
        public ActionResult formXoaSach(string id)
        {
            ViewBag.flagXoa = false;
            Models.sach x = db.saches.Find(id);
            int dem = x.luusaches.Where(t => t.masach == id).Count();
            if (dem==0) ViewBag.flagXoa = true;
            return View(x);
        }
        public ActionResult xoaSach(string id)
        {
            Models.sach sach = db.saches.Find(id);
            sach.tacgias.Clear();
            sach.theloais.Clear();
            db.saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("QuanLySach");
        }

        
        
    }
}