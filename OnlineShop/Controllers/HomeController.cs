using Model.Dao;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(4);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(4);
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }


        [ChildActionOnly]
      //  [OutputCache(Duration = 3600 * 24)]
        public ActionResult TopMenu1()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }

        //[ChildActionOnly]
      //  [OutputCache(Duration = 3600 * 24)]
        public ActionResult MainMenu1()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }
        [ChildActionOnly]
   //     [OutputCache(Duration = 3600 * 24)]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }


        [ChildActionOnly]
      //  [OutputCache(Duration = 3600 * 24)]
        public ActionResult Slide1()
        {
            var model = new SlideDao().ListAll();
            return PartialView(model);
        }



        [ChildActionOnly]
      //  [OutputCache(Duration = 3600 * 24)]
        public ActionResult Footer1()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }


        [ChildActionOnly]
  //      [OutputCache(Duration = 3600 * 24)]
        public ActionResult Showroom1()
        {
            var model = new SlideDao().GetShowRoomHome(1);
            return PartialView(model);
        }

        [ChildActionOnly]
   //     [OutputCache(Duration = 3600 * 24)]
        public ActionResult Product1()
        {
            var model = new ProductDao().ListNewProduct(8);
            return PartialView(model);
        }


        public ActionResult Index1()
        {
            //ViewBag.Slides = new SlideDao().ListAll();
            //var productDao = new ProductDao();
            //ViewBag.NewProducts = productDao.ListNewProduct(4);
            //ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(4);
            return View();
        }



    }
}