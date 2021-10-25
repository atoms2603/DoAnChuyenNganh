using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN.Controllers
{
    //Quản lý các thể loại. Sau này sẽ hiển thị các thể loại cho người dùng chọn lựa
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        public ActionResult IndexTheLoai()
        {
            return View();
        }
    }
}