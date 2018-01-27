using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TieuChuanWeb2.Models;
namespace TieuChuanWeb2.Controllers
{
    public class DanhMucTieuChuanController : Controller
    {
        // GET: DanhMucTieuChuan
        QL_TieuChuan2Entities db = new QL_TieuChuan2Entities();
        public ActionResult Index()
        {
            //if (Session["TaiKhoan"] != null)
            //{
            return View();
            //}
            //return RedirectToAction("DangNhap", "TaiKhoan");
        }
        [ValidateInput(false)]
        public ActionResult DanhMucTieuChuanPartial()
        {
            //if (Session["TaiKhoan"] != null)
            //{
            var model = db.dm_tieuchuan;
            return PartialView("_DanhMucTieuChuanPartial", model.OrderBy(n => n.ma_tieuchuan).ToList());
            //}
            //return RedirectToAction("DangNhap", "TaiKhoan");

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DanhMucTieuChuanPartialAddNew(TieuChuanWeb2.Models.dm_tieuchuan item)
        {
            //if (Session["TaiKhoan"] != null)
            //{
            var model = db.dm_tieuchuan;
            if (ModelState.IsValid)
            {
                try
                {
                    item.id = Guid.NewGuid();
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_DanhMucTieuChuanPartial", model.OrderBy(n => n.ma_tieuchuan).ToList());
            //}
            //return RedirectToAction("DangNhap", "TaiKhoan");

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DanhMucTieuChuanPartialUpdate(TieuChuanWeb2.Models.dm_tieuchuan item)
        {
            //if (Session["TaiKhoan"] != null)
            //{
            var model = db.dm_tieuchuan;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_DanhMucTieuChuanPartial", model.OrderBy(n => n.ma_tieuchuan).ToList());
            //}
            //return RedirectToAction("DangNhap", "TaiKhoan");

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DanhMucTieuChuanPartialDelete(System.Guid id)
        {
            //if (Session["TaiKhoan"] != null)
            //{
            var model = db.dm_tieuchuan;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_DanhMucTieuChuanPartial", model.OrderBy(n => n.ma_tieuchuan).ToList());
            //}
            //return RedirectToAction("DangNhap", "TaiKhoan");

        }
        //View Thêm mới
        public ActionResult ThemMoi()
        {
            //if (Session["TaiKhoan"] != null)
            //{
            // var da = db.dm_tieuchuan.SingleOrDefault(n => n.id == id);
            return View();
            //}
            //return RedirectToAction("DangNhap", "TaiKhoan");
        }
        //View Chỉnh sửa
        public ActionResult ChinhSua(System.Guid id)
        {
            //if (Session["TaiKhoan"] != null)
            //{
            // var da = db.dm_tieuchuan.SingleOrDefault(n => n.id == id);
            return View();
            //}
            //return RedirectToAction("DangNhap", "TaiKhoan");
        }
        //View Chỉnh sửa
        public ActionResult Xoa(System.Guid id)
        {
            var model = db.dm_tieuchuan;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            //return PartialView("_DanhMucTieuChuanPartial", model.OrderBy(n => n.ma_tieuchuan).ToList());
            return RedirectToAction("Index","DanhMucTieuChuan");
        }
        //-------------------------------------- Hiện lên nội dung trong Word
        public ActionResult NoiDungPartial(System.Guid id)
        {
            var model = db.dm_tieuchuan;
            //var x = model.SingleOrDefault(n => n.id == new Guid("D4EF2CE0-72DE-49CD-8BC7-158CBB8CEB3F"));
            var x = model.SingleOrDefault(n => n.id ==(System.Guid) id);
            // byte[] docBytes = RichEditExtension.SaveCopy("RichEditName", DevExpress.XtraRichEdit.DocumentFormat.Rtf);
            byte[] nd = Encoding.UTF8.GetBytes(x.noidung);
            //x.noidung = Encoding.ASCII.GetBytes(x.noidung);
            x.noidungbyte = nd;
            return PartialView("_NoiDungPartial", x);
        }
        public ActionResult NoiDungThemMoiPartial()
        {
            var model = db.dm_tieuchuan;
            //var x = model.SingleOrDefault(n => n.id == new Guid("D4EF2CE0-72DE-49CD-8BC7-158CBB8CEB3F"));
            //var x = model.SingleOrDefault(n => n.id == (System.Guid)id);
            dm_tieuchuan x = new dm_tieuchuan();
            x.id = Guid.NewGuid();
            x.noidung = "";
            // byte[] docBytes = RichEditExtension.SaveCopy("RichEditName", DevExpress.XtraRichEdit.DocumentFormat.Rtf);
            byte[] nd = Encoding.UTF8.GetBytes(x.noidung);
            //x.noidung = Encoding.ASCII.GetBytes(x.noidung);
            x.noidungbyte = nd;
            return PartialView("_NoiDungPartial", x);
        }
        //--------------------------------------End Hiện lên nội dung trong Word

    }
}