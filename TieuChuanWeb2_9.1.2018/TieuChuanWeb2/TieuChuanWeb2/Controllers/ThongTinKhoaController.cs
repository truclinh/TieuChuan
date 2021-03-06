﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TieuChuanWeb2.Models;
namespace TieuChuanWeb2.Controllers
{
    public class ThongTinKhoaController : Controller
    {
        // GET: ThongTinKhoa
        QL_TieuChuan2Entities db = new QL_TieuChuan2Entities();
        public ActionResult Index()
        {
            if (Session["TaiKhoan"] != null)
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        [ValidateInput(false)]
        public ActionResult ThongTinKhoaPartial()
        {
            if (Session["TaiKhoan"] != null)
            {
                var model = db.dm_khoa;
                return PartialView("_ThongTinKhoaPartial", model.OrderByDescending(n => n.id).ToList());
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        //[HttpPost, ValidateInput(false)]
        //public ActionResult ThongTinKhoaPartialAddNew(dm_khoa item)
        //{
        //    if (Session["TaiKhoan"] != null)
        //    {
        //        var model = db.dm_khoa;
        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                item.id = Guid.NewGuid();
        //                model.Add(item);
        //                db.SaveChanges();
        //            }
        //            catch (Exception e)
        //            {
        //                ViewData["EditError"] = e.Message;
        //            }
        //        }
        //        else
        //            ViewData["EditError"] = "Please, correct all errors.";
        //        return PartialView("_ThongTinKhoaPartial", model.OrderByDescending(n => n.id).ToList());
        //    }
        //    return RedirectToAction("DangNhap", "TaiKhoan");
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult ThongTinKhoaPartialUpdate(dm_khoa item)
        //{
        //    if (Session["TaiKhoan"] != null)
        //    {
        //        var model = db.dm_khoa;
        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                var modelItem = model.FirstOrDefault(it => it.id == item.id);
        //                if (modelItem != null)
        //                {
        //                    UpdateModel(modelItem);
        //                    db.SaveChanges();
        //                }
        //            }
        //            catch (Exception e)
        //            {
        //                ViewData["EditError"] = e.Message;
        //            }
        //        }
        //        else
        //            ViewData["EditError"] = "Please, correct all errors.";
        //        return PartialView("_ThongTinKhoaPartial", model.OrderByDescending(n => n.id).ToList());
        //    }
        //    return RedirectToAction("DangNhap", "TaiKhoan");
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult ThongTinKhoaPartialDelete(System.Guid id)
        //{
        //    if (Session["TaiKhoan"] != null)
        //    {
        //        var model = db.dm_khoa;
        //        if (id != null)
        //        {
        //            try
        //            {
        //                var item = model.FirstOrDefault(it => it.id == id);
        //                if (item != null)
        //                    model.Remove(item);
        //                db.SaveChanges();
        //            }
        //            catch (Exception e)
        //            {
        //                ViewData["EditError"] = e.Message;
        //            }
        //        }
        //        return PartialView("_ThongTinKhoaPartial", model.OrderByDescending(n => n.id).ToList());
        //    }
        //    return RedirectToAction("DangNhap", "TaiKhoan");
        //}
        public ActionResult SaveNewDocument(FormCollection f)
        {
            string txtMaKhoa = f["txtNew_makhoa"].ToString();
            string txtTenKhoa = f["txtNew_tenkhoa"].ToString();

            Guid id = System.Guid.NewGuid();
            var model = db.dm_khoa;
            if (ModelState.IsValid)
            {
                try
                {
                    db.sp_ThemMoiThongTinKhoa(id,txtMaKhoa, txtTenKhoa);
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
            return RedirectToAction("Index", "ThongTinKhoa");
            //return Content("<script type='text/javascript'>setInterval(function(){alert('Lưu thành công !!');window.opener.location.reload(true);},500);</script>");           
        }
        public ActionResult SaveEditDocument(FormCollection f)
        {
            Guid txtId = new Guid(f["txtHiddenId"].ToString());
            string txtMaKhoa = f["txt_makhoa"].ToString();
            string txtTenKhoa = f["txt_tenkhoa"].ToString();

            var model = db.dm_khoa;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == txtId);
                    if (modelItem != null)
                    {
                        db.sp_CapNhatThongTinKhoa(txtId, txtMaKhoa, txtTenKhoa);
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
            return RedirectToAction("Index", "ThongTinKhoa");
            //return Content("<script type='text/javascript'>setInterval(function(){alert('Lưu thành công !!');window.reload(true);},500);</script>");
        }
        public ActionResult Xoa(System.Guid id)
        {
            var model = db.dm_khoa;
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
            return RedirectToAction("Index", "ThongTinKhoa");
        }
    }
}