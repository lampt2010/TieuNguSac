using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AlbumImageController : Controller
    {
        // GET: Admin/AlbumImage
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new AlbumImageDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var model = new AlbumImage()
            {
               
                CreatedDate = DateTime.Now,
                Status = true,
                ViewCount=0,
                Number=0
            };
          //  SetViewBag();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AlbumImage model)
        {
            if (ModelState.IsValid)
            {
             
                new AlbumImageDao().Insert(model);
                return RedirectToAction("Index");
            }
           // SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new AlbumImageDao();
            var content = dao.GetByID(id);

         //   SetViewBag(content.CategoryID);

            return View(content);
        }


        [HttpPost]
        public ActionResult Edit(AlbumImage model)
        {
            if (ModelState.IsValid)
            {

            }
          //  SetViewBag(model.CategoryID);
            return View();
        }


        public JsonResult LoadImages(long id)
        {
            AlbumImageDao dao = new AlbumImageDao();
            var product = dao.GetByID(id);
            var images = product.Content;
            XElement xImages = XElement.Parse(images);
            List<string> listImagesReturn = new List<string>();

            foreach (XElement element in xImages.Elements())
            {
                listImagesReturn.Add(element.Value);
            }
            return Json(new
            {
                data = listImagesReturn
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveImages(long id, string images)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var listImages = serializer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("Images");

            foreach (var item in listImages)
            {
                var subStringItem = item.Substring(21);
                xElement.Add(new XElement("Image", subStringItem));
            }
            AlbumImageDao dao = new AlbumImageDao();
            try
            {
                dao.UpdateImages(id, xElement.ToString(),listImages.Count);
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }

        }




    }
}