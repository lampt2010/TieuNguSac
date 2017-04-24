using Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        // GET: Admin/Slide
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {



            var dao = new SlideDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
           
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag("");
            var model = new Slide() {

                CreatedDate=DateTime.Now.Date,
                Status=true,CreatedBy=""
            };

            return View(model);
        }

  

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Slide model,IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {

                foreach (var file in files)
                {
                    model.MoreImages += file.FileName + ",";
                    file.SaveAs(Server.MapPath("~/Uploads/" + file.FileName));
                }

                //  model.Language = culture.ToString();
                new SlideDao().Create(model);
                return RedirectToAction("Index");
            }
            SetViewBag("");
            return View();
        }

        public void SetViewBag(string TargetselectedId)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            // var dao = new ProductCategoryDao();
            items.Insert(0, (new SelectListItem { Text = "Slide", Value = "Slide" }));
            items.Insert(1, (new SelectListItem { Text = "Image", Value = "Image" }));
            ViewBag.Type = new SelectList(items.ToList(), "Value", "Text", TargetselectedId);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new SlideDao();
            var category = dao.GetByID(id);

            SetViewBag(category.Type);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Slide model, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                if (files.Count() >0)
                {
                    foreach (var file in files)
                    {
                        model.MoreImages += file.FileName + ",";
                        file.SaveAs(Server.MapPath("~/Uploads/" + file.FileName));
                    }
                }
                new SlideDao().Edit(model);
            }
            SetViewBag(model.Type);
            return View();
        }


    }
}