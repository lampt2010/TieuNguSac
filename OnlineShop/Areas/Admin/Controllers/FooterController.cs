using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class FooterController : Controller
    {
        // GET: Admin/Footer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new FooterDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
             SetViewBag(null);
            var model = new Footer()
            {

                Status=true,
                Content="",
            };


            return View(model);
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Footer model)
        {
            if (ModelState.IsValid)
            {

              //  var culture = Session[CommonConstants.CurrentCulture];
                //  model.Language = culture.ToString();
                new FooterDao().Create(model);
                return RedirectToAction("Index");
            }
          //  SetViewBag();
            return View();
        }

        public void SetViewBag(string selectedId)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            // var dao = new ProductCategoryDao();
            items.Insert(0, (new SelectListItem { Text = "Footer", Value = "Footer" }));
            items.Insert(1, (new SelectListItem { Text = "Map", Value = "Map" }));
            items.Insert(2, (new SelectListItem { Text = "Address", Value = "Address" }));

            ViewBag.Type = new SelectList(items.ToList(), "Value", "Text", selectedId);
        }

        public ActionResult Edit(int id)
        {
            var dao = new FooterDao();
            var category = dao.GetByID(id);

            SetViewBag(category.Type);

            return View(category);
        }


       
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Footer model)
        {
            if (ModelState.IsValid)
            {
                new FooterDao().Edit(model);
                return RedirectToAction("Index");
            }
            SetViewBag(model.Type);
            return View();
        }





    }
}