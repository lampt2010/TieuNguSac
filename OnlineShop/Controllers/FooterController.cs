using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LoadAddress()
        {
            var model = new FooterDao().GetAddress();


            return PartialView(model);
        }

        public ActionResult LoadMap()
        {
            var model = new FooterDao().GetMap();
            return PartialView(model);
        }







    }
}