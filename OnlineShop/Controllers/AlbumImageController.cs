using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class AlbumImageController : Controller
    {
        // GET: AlbumImage
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var model = new AlbumImageDao().ListAllPaging(page, pageSize);
            int totalRecord = 0;

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


        public ActionResult Detail(long id)
        {
            var model = new AlbumImageDao().GetByID(id);


            return View(model);
        }




    }
}