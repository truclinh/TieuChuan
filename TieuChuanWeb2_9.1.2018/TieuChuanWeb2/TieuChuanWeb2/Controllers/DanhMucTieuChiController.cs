using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TieuChuanWeb2.Controllers
{
    public class DanhMucTieuChiController : Controller
    {
        // GET: DanhMucTieuChi
        public ActionResult Index()
        {
            return View();
        }

        TieuChuanWeb2.Models.QL_TieuChuan2Entities db = new TieuChuanWeb2.Models.QL_TieuChuan2Entities();

        [ValidateInput(false)]
        public ActionResult DanhMucTieuChiPartial()
        {
            var model = db.dm_tieuchi;
            return PartialView("_DanhMucTieuChiPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DanhMucTieuChiPartialAddNew(TieuChuanWeb2.Models.dm_tieuchi item)
        {
            var model = db.dm_tieuchi;
            if (ModelState.IsValid)
            {
                try
                {
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
            return PartialView("_DanhMucTieuChiPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DanhMucTieuChiPartialUpdate(TieuChuanWeb2.Models.dm_tieuchi item)
        {
            var model = db.dm_tieuchi;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
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
            return PartialView("_DanhMucTieuChiPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DanhMucTieuChiPartialDelete(System.Guid id)
        {
            var model = db.dm_tieuchi;
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
            return PartialView("_DanhMucTieuChiPartial", model.ToList());
        }
    }
}