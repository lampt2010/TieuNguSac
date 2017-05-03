using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class KeywordController : Controller
    {
        // GET: Admin/Keyword
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new KeywordDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new Keyword()
            {

                
            };
            //  SetViewBag();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Keyword model)
        {
            if (ModelState.IsValid)
            {

                new KeywordDao().Insert(model);
                return RedirectToAction("Index");
            }
            // SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new KeywordDao();
            var content = dao.GetByID(id);

            //   SetViewBag(content.CategoryID);

            return View(content);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Keyword model)
        {
            if (ModelState.IsValid)
            {

            }
            //  SetViewBag(model.CategoryID);
            return View();
        }










    }
}