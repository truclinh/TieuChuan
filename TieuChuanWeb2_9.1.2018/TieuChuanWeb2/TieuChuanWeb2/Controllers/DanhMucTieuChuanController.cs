﻿using DevExpress.Web.Mvc;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
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
            return PartialView("_DanhMucTieuChuanPartial", model.OrderByDescending(n => n.ngaytao).ToList());
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
        public ActionResult ChinhSua(System.Guid? id)
        {
            //if (Session["TaiKhoan"] != null)
            //{
            var da = db.dm_tieuchuan.SingleOrDefault(n => n.id == id);
            return View(da);
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
            return RedirectToAction("Index", "DanhMucTieuChuan");
        }
        //-------------------------------------- Hiện lên nội dung trong Word
        public ActionResult SaveNewDocument(FormCollection f, Guid id)
        {
            string txtMaTC = f["txt_ma_tieuchuan"].ToString();
            string txtTenTC = f["txt_ten_tieuchuan"].ToString();
            //Guid id = System.Guid.NewGuid();
            var doc = DevExpress.Web.Office.DocumentManager.FindDocument("document" + id);
            string richEditString = Encoding.UTF8.GetString(doc.SaveCopy());
            var model = db.dm_tieuchuan;

            dm_tieuchuan item = new dm_tieuchuan();
            if (ModelState.IsValid)
            {
                try
                {
                    db.sp_ThemMoiTieuChuan(id, txtMaTC, txtTenTC, "Linh", DateTime.Now, richEditString);
                    //model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return View("Index");
            //return Content("<script type='text/javascript'>setInterval(function(){window.close();alert('Lưu thành công !!');window.opener.location.reload(true);},2000);</script>");
        }
        public ActionResult SaveEditDocument(Guid id, FormCollection f)
        {
            string txtMaTC = f["txt_ma_tieuchuan"].ToString();
            string txtTenTC = f["txt_ten_tieuchuan"].ToString();
            var doc = DevExpress.Web.Office.DocumentManager.FindDocument("document" + id);
            string richEditString = Encoding.UTF8.GetString(doc.SaveCopy());
            //string richEditString = Encoding.UTF8.GetString(RichEditExtension.SaveCopy("NoiDung", DocumentFormat.Html));

            var model = db.dm_tieuchuan;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == id);
                    if (modelItem != null)
                    {
                        db.sp_CapNhatTieuChuan(id, txtMaTC, txtTenTC, "Linh", DateTime.Now, richEditString);
                        //UpdateModel(modelItem);
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
            return View("Index");
            // return Content("<script type='text/javascript'>setInterval(function(){window.close();alert('Lưu thành công !!');window.opener.location.reload(true);},2000);</script>");
        }
        public ActionResult NoiDungPartial(System.Guid? id)
        {
            var model = db.dm_tieuchuan;
            //var x = model.SingleOrDefault(n => n.id == new Guid("D4EF2CE0-72DE-49CD-8BC7-158CBB8CEB3F"));
            var x = model.SingleOrDefault(n => n.id == id);
            // byte[] docBytes = RichEditExtension.SaveCopy("RichEditName", DevExpress.XtraRichEdit.DocumentFormat.Rtf);
            byte[] nd = Encoding.UTF8.GetBytes(x.noidung);
            x.noidungbyte = nd;
            //var y = model.SingleOrDefault(n => n.id == (System.Guid)id);
            return PartialView("_NoiDungPartial", x);
        }
        //public ActionResult TestPartial(System.Guid? id)
        //{
        //    return PartialView("TestPartial",y);
        //}

        public ActionResult NoiDungThemMoiPartial()
        {
            var model = db.dm_tieuchuan;
            //var x = model.SingleOrDefault(n => n.id == new Guid("D4EF2CE0-72DE-49CD-8BC7-158CBB8CEB3F"));
            dm_tieuchuan x = new dm_tieuchuan();
            x.id = Guid.NewGuid();
            x.noidung = "";
            x.noidungbyte = Encoding.UTF8.GetBytes(x.noidung);
            return PartialView("_NoiDungPartial", x);
        }
        //--------------------------------------End Hiện lên nội dung trong Word
    }
}