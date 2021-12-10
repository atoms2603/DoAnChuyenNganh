using System.Web.Mvc;
using System.Linq;
using BitMiracle.Docotic.Pdf;
using System.Collections.Generic;

namespace QLSachOnline.Controllers
{
    public class SachController : Controller
    {
        private QLSachOnline.Models.QLySachOnline db = new Models.QLySachOnline();
        // GET: Sach
        public ActionResult QuanLySach()
        {
            ViewBag.testTL = false;
            if (TempData["testTL"] != null) ViewBag.testTL = true;
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
            if (Session["flagMaSach"] != null)
                id = Session["flagMaSach"] as string;
            Session.Remove("flagMaSach");
            return View(db.saches.Find(id));
        }

        public ActionResult formThemSach()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult themSach(Models.sach sachN)
        {
            string[] dsID_TL = Request.Form.GetValues("maloai");
            string[] dsID_TG = Request.Form.GetValues("matg");
            string maSach = sachN.masach.ToUpper();
            string tenSach = sachN.tensach;

            if (ModelState.IsValid) { 
                if (db.saches.Find(maSach) == null)
                {
                    QLSachOnline.Models.sach sach = new Models.sach();

                    sach.namxuatban = sachN.namxuatban;
                    sach.masach = maSach.ToUpper();
                    sach.tensach = tenSach;
                    sach.manhaxuatban = sachN.manhaxuatban;
                    sach.nhaxuatban = db.nhaxuatbans.Find(sach.manhaxuatban);
                    sach.hinhanh = sachN.hinhanh;
                    sach.premium = sachN.premium;
                    sach.tomtat = sachN.tomtat;

                    if (dsID_TL != null)
                    {
                        foreach (var item in dsID_TL)
                        {
                            foreach (var item2 in db.theloais)
                            {
                                if (item.Equals(item2.maloai))
                                    sach.theloais.Add(item2);
                            }
                        }
                    }

                    if (dsID_TG != null)
                    {
                        foreach (var item in dsID_TG)
                        {
                            foreach (var item2 in db.tacgias)
                            {
                                if (item.Equals(item2.matg))
                                    sach.tacgias.Add(item2);
                            }
                        }
                    }

                    db.saches.Add(sach);
                    db.SaveChanges();
                    return RedirectToAction("QuanLySach");
                }
                ModelState.AddModelError("masach", "Mã trùng !! Vui lòng nhập mã khác.");
            }
            return View("formThemSach");
        }
        public ActionResult formChinhSua(string id)
        {
            return View(db.saches.Find(id));
        }
        [HttpPost]
        public ActionResult ChinhSuaSach(Models.sach sachN)
        {
            if (ModelState.IsValid)
            {
                string[] dsID_TL = Request.Form.GetValues("maloai");
                string[] dsID_TG = Request.Form.GetValues("matg");
                Models.sach sachsua = db.saches.Find(sachN.masach);

                if (sachsua != null) { 

                    if (dsID_TL != null) {
                        sachsua.theloais.Clear();
                        foreach (var item in dsID_TL)
                        {
                            foreach (var item2 in db.theloais)
                            {
                                if (item.Equals(item2.maloai))
                                    sachsua.theloais.Add(item2);
                            }
                        }
                    }

                    if (dsID_TG != null) {
                        sachsua.tacgias.Clear();
                        foreach (var item in dsID_TG)
                        {
                            foreach (var item2 in db.tacgias)
                            {
                                if (item.Equals(item2.matg))
                                    sachsua.tacgias.Add(item2);
                            }
                        }
                    }
                    sachsua.tensach = sachN.tensach;
                    sachsua.namxuatban = sachN.namxuatban;
                    sachsua.manhaxuatban = sachN.manhaxuatban;
                    sachsua.nhaxuatban = db.nhaxuatbans.Find(sachsua.manhaxuatban);
                    sachsua.premium = sachN.premium;
                    sachsua.hinhanh = sachN.hinhanh;
                    sachsua.tomtat = sachN.tomtat;

                    db.SaveChanges();
                    return RedirectToAction("QuanLySach");
                }
            }
            return RedirectToAction("formChinhSua","Sach",sachN.masach);
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
            if (sach != null) {
                db.nhaxuatbans.Find(sach.manhaxuatban).saches.Remove(sach);
                
                sach.tacgias.Clear();
                sach.theloais.Clear();
                sach.chuongs.Clear();

                db.saches.Remove(sach);
                db.SaveChanges();
            }
            return RedirectToAction("QuanLySach");
        }

        //HIỂN THỊ NỘI DUNG CHƯƠNG
        public ActionResult formNoiDung(string id)
        {
            string pathFile = Server.MapPath("/Files_Truyen/");


            //Lấy mã sách và mã chương
            string[] arrayMa = id.Split('-');
            string maSach = arrayMa[0];
            string maChuong = arrayMa[1];
            
            Models.chuong chuong = new Models.chuong();
            Models.sach sach = db.saches.Find(maSach);
            string[] arrayMaChuong = new string[sach.chuongs.Count];

            foreach (var item in sach.chuongs)
            {
                if (item.machuong == maChuong)
                {
                    if (item.noidung != null) { 
                        string[] fotmatNoiDung = item.noidung.Split(',');
                        if(fotmatNoiDung.Count() < 1) ViewBag.noiDung = docPdf(pathFile + item.noidung);
                        else ViewBag.noiDung = docPdf(pathFile+fotmatNoiDung[0]);

                        chuong = item;
                        break;
                    }
                }
            }
            int k = 0;
            foreach(Models.chuong item in sach.chuongs)
            {
                arrayMaChuong[k] = item.machuong;
                k++;
            }
            if (arrayMaChuong.Length <= 1)
                ViewBag.oneChuong = true;
            else
            {
                if (maChuong.Equals(arrayMaChuong[0]))
                    ViewBag.nextChuong = arrayMaChuong[1];
                else if (maChuong.Equals(arrayMaChuong[arrayMaChuong.Length - 1]))
                    ViewBag.previousChuong = arrayMaChuong[arrayMaChuong.Length - 2];
                else
                {
                    for (int i = 0; i < arrayMaChuong.Length; i++)
                    {
                        if (maChuong.Equals(arrayMaChuong[i]))
                        {
                            ViewBag.nextChuong = arrayMaChuong[i + 1];
                            ViewBag.previousChuong = arrayMaChuong[i - 1];
                            break;
                        }
                    }
                }
            }
            ViewBag.sachChon = chuong;
            return View(sach);
        }
        //ĐỌC FILE PDF
        public string docPdf(string path)
        {
            using (PdfDocument pdf = new PdfDocument(path))
            {
                var options = new PdfTextExtractionOptions
                {
                    SkipInvisibleText = true,
                    WithFormatting = true
                };

                string formattedText = pdf.GetText(options);
                return formattedText;
            }
        }


        //Xử lý sách
        public ActionResult yeuThich(string id)
        {
            if ((bool)Session["isLogin"]) 
            {
                Models.userlogin user = Session["Login"] as Models.userlogin;
                if (db.luusaches.Where(x=>x.masach==id).Where(x=>x.taikhoan==user.taikhoan).ToList().Count!=0)
                {
                    db.luusaches.Remove(db.luusaches.Where(x => x.masach == id).Where(x=>x.taikhoan==user.taikhoan).First());
                }
                else 
                {
                    Models.luusach luusach = new Models.luusach();
                    luusach.masach = id;
                    luusach.taikhoan = user.taikhoan;
                    luusach.ngayluu = System.DateTime.Now;
                    db.luusaches.Add(luusach);
                }
                db.SaveChanges();
                Session["Login"] = db.userlogins.Find(user.taikhoan);
                return View("indexSach", db.saches.Find(id));
            }
            return RedirectToAction("IndexDangNhap", "User");
        }
    }
}