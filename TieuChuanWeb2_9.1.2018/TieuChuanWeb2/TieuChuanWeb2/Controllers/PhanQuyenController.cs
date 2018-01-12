using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TieuChuanWeb2.Models;
namespace TieuChuanWeb2.Controllers
{
    public class PhanQuyenController : Controller
    {
        // GET: PhanQuyen
        QL_TieuChuan2Entities db = new QL_TieuChuan2Entities();
        public JsonResult getDanhMucPhanQuyen(string ma_nsd)
        {
            var lstDMPQ = db.spDanhMucPhanQuyen(ma_nsd);
            return Json(new SelectList(lstDMPQ, "ten_menu", "ma_menu", JsonRequestBehavior.AllowGet));
        }
        public JsonResult getPhanQuyenNguoiDung(string ma_nsd)
        {
            var lstPQND = db.spPhanQuyenNguoiDung(ma_nsd);
            return Json(new SelectList(lstPQND, "ten_menu", "ma_menu", JsonRequestBehavior.AllowGet));
        }
        public ActionResult Index()
        {
            ViewBag.TK = new SelectList(db.ht_dm_nsd.ToList().OrderBy(n => n.ten_nsd), "ma_nsd", "ten_nsd");
            return View();
        }

        [ValidateInput(false)]
        public ActionResult DanhMucPhanQuyenPartial()
        {
            var model = db.ht_dm_menu;
            return PartialView("_DanhMucPhanQuyenPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DanhMucPhanQuyenPartialAddNew(TieuChuanWeb2.Models.ht_dm_menu item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_DanhMucPhanQuyenPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DanhMucPhanQuyenPartialUpdate(TieuChuanWeb2.Models.ht_dm_menu item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_DanhMucPhanQuyenPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DanhMucPhanQuyenPartialDelete(System.Guid id)
        {
            var model = new object[0];
            if (id != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_DanhMucPhanQuyenPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult PhanQuyenNguoiDungPartial()
        {
            var model = db.ht_nsd_menu;
            return PartialView("_PhanQuyenNguoiDungPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult PhanQuyenNguoiDungPartialAddNew(TieuChuanWeb2.Models.ht_nsd_menu item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_PhanQuyenNguoiDungPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult PhanQuyenNguoiDungPartialUpdate(TieuChuanWeb2.Models.ht_nsd_menu item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_PhanQuyenNguoiDungPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult PhanQuyenNguoiDungPartialDelete(System.Guid id)
        {
            var model = new object[0];
            if (id != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_PhanQuyenNguoiDungPartial", model);
        }
    }
}