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
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Create()
        {
            SetViewBag();
            var model = new Category()
            {
                CreatedDate = DateTime.Now.Date,
                CreatedBy= User.Identity.Name,
                Status=true,ShowOnHome=true
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var currentCulture = Session[CommonConstants.CurrentCulture];
                model.Language = currentCulture.ToString();
                var id = new CategoryDao().Insert(model);
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

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            List<SelectListItem> items = new SelectList(dao.ListAll(), "ID", "Name", selectedId).ToList();
            items.Insert(0, (new SelectListItem { Text = "Danh mục gốc", Value = "0" }));
            ViewBag.ParentID = items;
        }


        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new CategoryDao();
            var category = dao.GetByID(id);

            SetViewBag(category.ParentID);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                new CategoryDao().Edit(model);
            }
            SetViewBag(model.ParentID);
            return View();
        }



    }
}