using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TieuChuanWeb2.Models;
namespace TieuChuanWeb2.Controllers
{
    public class QuanLyNguoiDungController : Controller
    {
        // GET: QuanLyNguoiDung
        QL_TieuChuan2Entities db1 = new QL_TieuChuan2Entities();
        public ActionResult Index()
        {
            if (Session["TaiKhoan"] != null)
            { 
                TieuChuanDTO tc = new TieuChuanDTO();
                var lstKhoa = tc.getAllKhoa().OrderBy(n => n.makhoa);
                var lstBoMon = tc.getAllBoMon().OrderBy(n => n.mabomon);
                //ViewBag.DMKhoa = new SelectList(db.dm_khoa.ToList().OrderBy(n => n.makhoa), "makhoa", "tenkhoa");
                // ViewBag.DMBoMon = new SelectList(db.dm_bomon.ToList().OrderBy(n => n.mabomon), "mabomon", "tenbomon");
                ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
                ViewBag.DMBoMon = lstBoMon.Select(i => new { TenBM = i.tenbomon, MaBM = i.mabomon });
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");

        }
        [ValidateInput(false)]
        public ActionResult QuanLyNguoiDungPartial()
        {
            if (Session["TaiKhoan"] != null)
            {
                TieuChuanDTO tc = new TieuChuanDTO();
                var lstKhoa = tc.getAllKhoa().OrderBy(n => n.makhoa);
                var lstBoMon = tc.getAllBoMon().OrderBy(n => n.mabomon);
                //ViewBag.DMKhoa = new SelectList(db.dm_khoa.ToList().OrderBy(n => n.makhoa), "makhoa", "tenkhoa");
                // ViewBag.DMBoMon = new SelectList(db.dm_bomon.ToList().OrderBy(n => n.mabomon), "mabomon", "tenbomon");
                ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
                ViewBag.DMBoMon = lstBoMon.Select(i => new { TenBM = i.tenbomon, MaBM = i.mabomon });
                var model = db1.ht_dm_nsd;
                return PartialView("_QuanLyNguoiDungPartial", model.OrderByDescending(n => n.ngaytao).ToList());
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyNguoiDungPartialAddNew(ht_dm_nsd item)
        {
            if (Session["TaiKhoan"] != null)
            {
                TieuChuanDTO tc = new TieuChuanDTO();
            var lstKhoa = tc.getAllKhoa().OrderBy(n => n.makhoa);
            var lstBoMon = tc.getAllBoMon().OrderBy(n => n.mabomon);
            //ViewBag.DMKhoa = new SelectList(db.dm_khoa.ToList().OrderBy(n => n.makhoa), "makhoa", "tenkhoa");
            // ViewBag.DMBoMon = new SelectList(db.dm_bomon.ToList().OrderBy(n => n.mabomon), "mabomon", "tenbomon");
            ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
            ViewBag.DMBoMon = lstBoMon.Select(i => new { TenBM = i.tenbomon, MaBM = i.mabomon });

            var model = db1.ht_dm_nsd;
            if (ModelState.IsValid)
            {
                try
                {
                    //item.matkhau = Encryptor.MDSHash(item.matkhau);
                    item.id = Guid.NewGuid();
                    item.nguoitao = Session["TenDangNhap"].ToString();
                    item.ngaytao = System.DateTime.Now;
                    model.Add(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_QuanLyNguoiDungPartial", model.OrderByDescending(n => n.ngaytao).ToList());
        }
          return RedirectToAction("DangNhap", "TaiKhoan");
    }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyNguoiDungPartialUpdate(ht_dm_nsd item)
        {
            if (Session["TaiKhoan"] != null)
            {
                TieuChuanDTO tc = new TieuChuanDTO();
                var lstKhoa = tc.getAllKhoa().OrderBy(n => n.makhoa);
                var lstBoMon = tc.getAllBoMon().OrderBy(n => n.mabomon);
                //ViewBag.DMKhoa = new SelectList(db.dm_khoa.ToList().OrderBy(n => n.makhoa), "makhoa", "tenkhoa");
                // ViewBag.DMBoMon = new SelectList(db.dm_bomon.ToList().OrderBy(n => n.mabomon), "mabomon", "tenbomon");
                ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
                ViewBag.DMBoMon = lstBoMon.Select(i => new { TenBM = i.tenbomon, MaBM = i.mabomon });

                var model = db1.ht_dm_nsd;
                if (ModelState.IsValid)
                {
                    try
                    {
                        var modelItem = model.FirstOrDefault(it => it.id == item.id);
                        if (modelItem != null)
                        {
                            //modelItem.matkhau = Encryptor.MDSHash(modelItem.matkhau);
                            modelItem.nguoisua = Session["TenDangNhap"].ToString();
                            modelItem.ngaysua = System.DateTime.Now;
                            UpdateModel(modelItem);
                            db1.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        ViewData["EditError"] = e.Message;
                    }
                }
                else
                    ViewData["EditError"] = "Please, correct all errors.";
                return PartialView("_QuanLyNguoiDungPartial", model.OrderByDescending(n => n.ngaytao).ToList());
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyNguoiDungPartialDelete(System.Guid id)
        {
            if (Session["TaiKhoan"] != null)
            {
                TieuChuanDTO tc = new TieuChuanDTO();
                var lstKhoa = tc.getAllKhoa().OrderBy(n => n.makhoa);
                var lstBoMon = tc.getAllBoMon().OrderBy(n => n.mabomon);
                //ViewBag.DMKhoa = new SelectList(db.dm_khoa.ToList().OrderBy(n => n.makhoa), "makhoa", "tenkhoa");
                // ViewBag.DMBoMon = new SelectList(db.dm_bomon.ToList().OrderBy(n => n.mabomon), "mabomon", "tenbomon");
                ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
                ViewBag.DMBoMon = lstBoMon.Select(i => new { TenBM = i.tenbomon, MaBM = i.mabomon });

                var model = db1.ht_dm_nsd;
                if (id != null)
                {
                    try
                    {
                        var item = model.FirstOrDefault(it => it.id == id);
                        if (item != null)
                            model.Remove(item);
                        db1.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        ViewData["EditError"] = e.Message;
                    }
                }
                return PartialView("_QuanLyNguoiDungPartial", model.OrderByDescending(n => n.ngaytao).ToList());
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
    }
}