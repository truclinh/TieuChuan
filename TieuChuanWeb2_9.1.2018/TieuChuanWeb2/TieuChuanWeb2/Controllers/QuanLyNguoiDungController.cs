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
        public ActionResult Index()
        {
            TieuChuanDTO qt = new TieuChuanDTO();
            var lstKhoa = qt.getAllKhoa().OrderBy(n => n.makhoa);
            var lstBoMon = qt.getAllBoMon().OrderBy(n => n.mabomon);
            //ViewBag.DMKhoa = new SelectList(db.dm_khoa.ToList().OrderBy(n => n.makhoa), "makhoa", "tenkhoa");
            // ViewBag.DMBoMon = new SelectList(db.dm_bomon.ToList().OrderBy(n => n.mabomon), "mabomon", "tenbomon");
            ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
            ViewBag.DMBoMon = lstBoMon.Select(i => new { TenBM = i.tenbomon, MaBM = i.mabomon });
            return View();
        }
        TieuChuanWeb2.Models.QL_TieuChuan2Entities db1 = new TieuChuanWeb2.Models.QL_TieuChuan2Entities();

        [ValidateInput(false)]
        public ActionResult QuanLyNguoiDungPartial()
        {
            TieuChuanDTO qt = new TieuChuanDTO();
            var lstKhoa = qt.getAllKhoa().OrderBy(n => n.makhoa);
            var lstBoMon = qt.getAllBoMon().OrderBy(n => n.mabomon);
            //ViewBag.DMKhoa = new SelectList(db.dm_khoa.ToList().OrderBy(n => n.makhoa), "makhoa", "tenkhoa");
            // ViewBag.DMBoMon = new SelectList(db.dm_bomon.ToList().OrderBy(n => n.mabomon), "mabomon", "tenbomon");
            ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
            ViewBag.DMBoMon = lstBoMon.Select(i => new { TenBM = i.tenbomon, MaBM = i.mabomon });
            var model = db1.ht_dm_nsd;
            return PartialView("_QuanLyNguoiDungPartial", model.OrderByDescending(n => n.ngaytao).ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyNguoiDungPartialAddNew(TieuChuanWeb2.Models.ht_dm_nsd item)
        {
            TieuChuanDTO qt = new TieuChuanDTO();
            var lstKhoa = qt.getAllKhoa().OrderBy(n => n.makhoa);
            var lstBoMon = qt.getAllBoMon().OrderBy(n => n.mabomon);
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
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyNguoiDungPartialUpdate(TieuChuanWeb2.Models.ht_dm_nsd item)
        {
            TieuChuanDTO qt = new TieuChuanDTO();
            var lstKhoa = qt.getAllKhoa().OrderBy(n => n.makhoa);
            var lstBoMon = qt.getAllBoMon().OrderBy(n => n.mabomon);
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
        [HttpPost, ValidateInput(false)]
        public ActionResult QuanLyNguoiDungPartialDelete(System.Guid id)
        {
            TieuChuanDTO qt = new TieuChuanDTO();
            var lstKhoa = qt.getAllKhoa().OrderBy(n => n.makhoa);
            var lstBoMon = qt.getAllBoMon().OrderBy(n => n.mabomon);
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
    }
}