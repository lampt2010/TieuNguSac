
using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SinglePageController : Controller
    {
        // GET: Admin/SinglePage
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {

            var dao = new SinglePageDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);

           
        }


        public ActionResult Create()
        {
          
            var model = new SinglePage()
            {
                
                Status = true,Lang="vi"
             
            };
            SetViewBag(model.Type);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SinglePage model)
        {
            if (ModelState.IsValid)
            {
                var currentCulture = Session[CommonConstants.CurrentCulture];
                model.Lang = currentCulture.ToString();
                var id = new SinglePageDao().Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", StaticResources.Resources.InsertCategoryFailed);
                }
            }
            return View(model);
        }



        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new SinglePageDao();
            var category = dao.GetByID(id);

            SetViewBag(category.Type);

            return View(category);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SinglePage model)
        {
            if (ModelState.IsValid)
            {
                new SinglePageDao().Edit(model);
            }
         
            return View();
        }

        public void SetViewBag(string TargetselectedId)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            // var dao = new ProductCategoryDao();
            items.Insert(0, (new SelectListItem { Text = "Video", Value = "Video" }));
            items.Insert(1, (new SelectListItem { Text = "Content", Value = "Content" }));
            items.Insert(2, (new SelectListItem { Text = "Custom", Value = "Customer" }));

            ViewBag.Type = new SelectList(items.ToList(), "Value", "Text", TargetselectedId);

        }

      







    }
}