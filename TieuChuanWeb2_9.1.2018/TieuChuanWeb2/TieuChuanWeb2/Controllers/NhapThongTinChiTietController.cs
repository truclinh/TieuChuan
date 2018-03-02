using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TieuChuanWeb2.Models;
namespace TieuChuanWeb2.Controllers
{
    public class NhapThongTinChiTietController : Controller
    {
        // GET: NhapThongTinChiTiet
        QL_TieuChuan2Entities db = new QL_TieuChuan2Entities();
        public ActionResult Index()
        {
            //var model = db.hs_noidung.ToList();
            return View();
        }

        TieuChuanWeb2.Models.QL_TieuChuan2Entities db1 = new TieuChuanWeb2.Models.QL_TieuChuan2Entities();

        [ValidateInput(false)]
        public ActionResult NhapThongTinChiTietPartial()
        {
            var model = db1.hs_noidung;
            return PartialView("_NhapThongTinChiTietPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NhapThongTinChiTietPartialAddNew(TieuChuanWeb2.Models.hs_noidung item)
        {
            var model = db1.hs_noidung;
            if (ModelState.IsValid)
            {
                try
                {
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
            return PartialView("_NhapThongTinChiTietPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult NhapThongTinChiTietPartialUpdate(TieuChuanWeb2.Models.hs_noidung item)
        {
            var model = db1.hs_noidung;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
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
            return PartialView("_NhapThongTinChiTietPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult NhapThongTinChiTietPartialDelete(System.Guid id)
        {
            var model = db1.hs_noidung;
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
            return PartialView("_NhapThongTinChiTietPartial", model.ToList());
        }
    }
}