using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class TheLoaiController : Controller
    {
        private Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: TheLoai
        public ActionResult QuanLyTheLoai()
        {
            ViewBag.tl = db.theloais;
            return View(db.theloais);
        }

        public ActionResult thaoTacTheLoai(string id)
        {
            //if (db.theloais.Find(id).sach_theloai.Count == 0)
            //    ViewBag.flagXoa = true;
            return View(db.theloais.Find(id));
        }

        [HttpPost]
        public ActionResult suaTheLoai(string id)
        {
            QLSachOnline.Models.theloai tl = db.theloais.Find(id);
            tl.tentl = Request["tentl"].ToString();
            tl.ghichu = Request["ghichu"].ToString();
            db.SaveChanges();
            return RedirectToAction("QuanLyTheLoai");
        }
        public ActionResult xoaTheLoai(string id)
        {
            db.theloais.Remove(db.theloais.Find(id));
            db.SaveChanges();
            return RedirectToAction("QuanLyTheLoai");   
        }

        [HttpPost]
        public ActionResult themTheLoai(QLSachOnline.Models.theloai tl)
        {
            if (ModelState.IsValid)
            {
                db.theloais.Add(tl);
                db.SaveChanges();
            }
            return RedirectToAction("QuanLyTheLoai");
        }
    }
}