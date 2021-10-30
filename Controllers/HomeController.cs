using System.Web.Mvc;

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
    }
}