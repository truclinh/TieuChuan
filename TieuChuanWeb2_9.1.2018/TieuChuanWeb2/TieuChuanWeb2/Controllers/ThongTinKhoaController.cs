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
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ThongTinKhoaPartial()
        {
            var model = new object[0];
            return PartialView("_ThongTinKhoaPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ThongTinKhoaPartialAddNew(TieuChuanWeb2.Models.dm_khoa item)
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
            return PartialView("_ThongTinKhoaPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ThongTinKhoaPartialUpdate(TieuChuanWeb2.Models.dm_khoa item)
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
            return PartialView("_ThongTinKhoaPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ThongTinKhoaPartialDelete(System.Guid id)
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
            return PartialView("_ThongTinKhoaPartial", model);
        }
    }
}