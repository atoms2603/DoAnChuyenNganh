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
        public ActionResult themTheLoai()
        {
            return View();
        }
    }
}