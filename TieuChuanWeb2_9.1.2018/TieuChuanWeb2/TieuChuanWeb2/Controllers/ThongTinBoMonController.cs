using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TieuChuanWeb2.Models;
namespace TieuChuanWeb2.Controllers
{
    public class ThongTinBoMonController : Controller
    {
        // GET: ThongTinBoMon
        QL_TieuChuan2Entities db = new QL_TieuChuan2Entities();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ThongTinBoMonPartial()
        {
            TieuChuanDTO tc = new TieuChuanDTO();
            var lstKhoa = tc.getAllKhoa().OrderBy(n => n.makhoa);
            ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });

            var model = db.dm_bomon;
            return PartialView("_ThongTinBoMonPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ThongTinBoMonPartialAddNew(TieuChuanWeb2.Models.dm_bomon item)
        {
            var model = db.dm_bomon;
            TieuChuanDTO tc = new TieuChuanDTO();
            var lstKhoa = tc.getAllKhoa().OrderBy(n => n.makhoa);
            ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
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
            return PartialView("_ThongTinBoMonPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ThongTinBoMonPartialUpdate(TieuChuanWeb2.Models.dm_bomon item)
        {
            var model = db.dm_bomon ;
            TieuChuanDTO tc = new TieuChuanDTO();
            var lstKhoa = tc.getAllKhoa().OrderBy(n => n.makhoa);
            ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
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
            return PartialView("_ThongTinBoMonPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ThongTinBoMonPartialDelete(System.Guid id)
        {
            var model = db.dm_bomon;
            TieuChuanDTO tc = new TieuChuanDTO();
            var lstKhoa = tc.getAllKhoa().OrderBy(n => n.makhoa);
            ViewBag.DMKhoa = lstKhoa.Select(i => new { TenKhoa = i.tenkhoa, MaKhoa = i.makhoa });
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
            return PartialView("_ThongTinBoMonPartial", model.ToList());
        }
    }
}