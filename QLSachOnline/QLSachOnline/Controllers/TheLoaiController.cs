using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class TheLoaiController : Controller
    {
        private Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: TheLoai
        public ActionResult QuanLyTheLoai()
        {
            if (TempData["maRong"] != null)
                ViewBag.flagMaRong = true;
            if (TempData["matrung"] != null)
                ViewBag.flagCo = true;

            return View(db.theloais);
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
            if(Request["maloai"].ToString()=="")
            {
                TempData["maRong"] = true;
                return RedirectToAction("QuanLyTheLoai");
            }
            if (ModelState.IsValid)
            {
                Models.theloai x = db.theloais.Find(tl.maloai);
                if (x == null)
                {
                    tl.maloai = tl.maloai.ToUpper();
                    db.theloais.Add(tl);
                    db.SaveChanges();
                }
                else TempData["maTrung"] = true;
            }
            return RedirectToAction("QuanLyTheLoai");
        }
        
    }
}