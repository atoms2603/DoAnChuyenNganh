using System.Web.Mvc;

namespace QLSachOnline.Controllers
{
    public class TheLoaiController : Controller
    {
        private Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: TheLoai
        public ActionResult QuanLyTheLoai()
        {
            return View(db.theloais);
        }
        [HttpPost]
        public ActionResult suaTheLoai(string id)
        {
            QLSachOnline.Models.theloai tl = db.theloais.Find(id);
            if(Request["tentl"]!=null)
                tl.tentl = Request["tentl"].ToString();
            if(Request["ghichu"]!=null)
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
                if (db.theloais.Find(tl.maloai) == null)
                {
                    tl.maloai = tl.maloai.ToUpper();
                    db.theloais.Add(tl);
                    db.SaveChanges();
                    return RedirectToAction("QuanLyTheLoaiTest");
                }
                ModelState.AddModelError("maloai", "Mã trùng, vui lòng nhập lại !");
            }
            return View("QuanLyTheLoai");
        }
        
    }
}