using DevExpress.Web.Mvc;
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

        [HttpPost, ValidateInput(false)]
        public ActionResult ThongTinKhoaPartialAddNew(dm_khoa item)
        {
            if (Session["TaiKhoan"] != null)
            {
                var model = db.dm_khoa;
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
                return PartialView("_ThongTinKhoaPartial", model.OrderByDescending(n => n.id).ToList());
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ThongTinKhoaPartialUpdate(dm_khoa item)
        {
            if (Session["TaiKhoan"] != null)
            {
                var model = db.dm_khoa;
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
                return PartialView("_ThongTinKhoaPartial", model.OrderByDescending(n => n.id).ToList());
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ThongTinKhoaPartialDelete(System.Guid id)
        {
            if (Session["TaiKhoan"] != null)
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
                return PartialView("_ThongTinKhoaPartial", model.OrderByDescending(n => n.id).ToList());
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
    }
}