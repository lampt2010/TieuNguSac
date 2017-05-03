using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class SinglePageController : Controller
    {
        // GET: SinglePage
        public ActionResult Index()
        {


            var model = new SinglePageDao().ListAll();
            return View(model);
        }

        public ActionResult LoadDanhSachVideo(int page = 1, int pageSize = 1)
        {
           // var model = new SinglePageDao().ListAll();
           // var category = new CategoryDao().ViewDetail(cateId);
          //  ViewBag.Category = category;
            int totalRecord = 0;
            var model = new SinglePageDao().ListByPagging("Video", ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);

           
        }


        public ActionResult LoadSingleVideo(int id)
        {
            var model = new SinglePageDao().GetByID(id);

            return View(model);
        }

        public ActionResult LoadOtherVideo(int id)
        {
            var model = new SinglePageDao().ListVideoOther(id);

            return View(model);
        }

        public ActionResult LoadDoiTac()
        {
            var model = new SinglePageDao().ListAllCustom();

            return View(model);
        }

        public ActionResult DetailSinglePage(long id)
        {
            var model = new SinglePageDao().GetByID(id);
            return View(model);
        }



    }
}