using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class KeywordController : Controller
    {
        // GET: Keyword
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetFacebook()
        {
            var model = new KeywordDao().GetByID("Facebook");
            return PartialView(model);
        }




    }
}