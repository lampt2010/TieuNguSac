using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Admin/Menu
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new MenuDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            SetViewBag(null,null,null);
            var model = new Menu()
            {

                Status = true,
               Level="00000",
               Target="_blank",
               DisplayOrder=1,
               Link="/"
            };


            return View(model);
        }

        public void SetViewBag(string TargetselectedId,int? MenyTypeselectedId1=null,int? ParentselectId2=null)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            // var dao = new ProductCategoryDao();
            items.Insert(0, (new SelectListItem { Text = "_blank", Value = "_blank" }));
            items.Insert(1, (new SelectListItem { Text = "_self", Value = "_self" }));
            ViewBag.Target = new SelectList(items.ToList(), "Value", "Text", TargetselectedId);


            var MenuType = new MenuTypeDao();
            List<SelectListItem> item1 = new SelectList(MenuType.ListAll(), "ID", "Name", MenyTypeselectedId1).ToList();
                
         //   item1.Insert(0, (new SelectListItem { Text = "Cấp cao nhất", Value = "0" }));
            ViewBag.TypeID = item1;

            var Menu = new MenuDao();
            List<SelectListItem> item2 = new SelectList(Menu.ListAll(), "ID", "Text", ParentselectId2).ToList();
            item2.Insert(0, (new SelectListItem { Text = "Cấp cha", Value = "0" }));
            ViewBag.ParentId = item2;
                





        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Menu model)
        {
            if (ModelState.IsValid)
            {

                //  var culture = Session[CommonConstants.CurrentCulture];
                //  model.Language = culture.ToString();
               if(model.ParentId==0)// trường hợp là cấp cao nhất
                {
                    var menuold = new MenuDao().GetMenuLast();
                    model.Level = (10000+menuold.ID+1).ToString().Substring(1);
                    model.Level = "0" + model.Level;

                }
                else // trường hợp là cấp 2 trờ lên
                {
                    string level = new MenuDao().Level(int.Parse(model.ParentId.ToString()));
                    var menuold = new MenuDao().GetMenuLast();
                    model.Level = (10000 + menuold.ID+1).ToString().Substring(1);
                    string numberCode = string.Format("{0}","0"+ model.Level);
                    model.Level = level + numberCode;//cong them cho no 1 cap nua
                  

                }

                new MenuDao().Create(model);
                return RedirectToAction("Index");
            }
            //  SetViewBag();
            return View();
        }


        public ActionResult Edit(int id)
        {
            var dao = new MenuDao();
            var menu = dao.GetByID(id);

            SetViewBag(menu.Target,menu.TypeID,menu.ParentId);

            return View(menu);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Menu model)
        {
            if (ModelState.IsValid)
            {


                if (model.ParentId == 0)// trường hợp là cấp cao nhất
                {
                    var menuold = new MenuDao().GetMenuLast();
                    model.Level = (10000 + model.ID).ToString().Substring(1);
                    model.Level = "0" + model.Level;

                }
                else // trường hợp là cấp 2 trờ lên
                {
                    string level = new MenuDao().Level(int.Parse(model.ParentId.ToString()));
                   // var menuold = new MenuDao().GetMenuLast();
                    model.Level = (10000 + model.ID).ToString().Substring(1);
                    string numberCode = string.Format("{0}","0"+ model.Level);
                    model.Level = level + numberCode;//cong them cho no 1 cap nua

                    new MenuDao().Edit(model);

                }






                return RedirectToAction("Index");
            }
           // SetViewBag(model.Type);
            return View();
        }






    }
}