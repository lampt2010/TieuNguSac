using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new OrderDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }



        public JsonResult LoadOrder(long id)
        {
            var dao = new OrderDao();
            var productDetail = dao.GetListOrderDetail(id);
            var product = new ProductDao();
           
            List<string> listImagesReturn = new List<string>();

            foreach (var element in productDetail)
            {
              var pro=  product.ViewDetail(element.ProductID);

                string s = "<tr class=\"tbody\"><td data-th=\"Ảnh sản phẩm\" class=\"td_1\"><div class=\"img_gh\">";
                s += "<img src = \""+pro.Image+"\" alt=\"\"></div>";
                s += "</td><td data-th=\"Tên sản phẩm\" class=\"td_2\">";
                s += "<div class=\"gh_name_sp\"><a href = \"#\" >" + pro.Name + " </a></div>";
                s += "</td><td data-th=\"Số lượng\" class=\"td_3\"><input type = \"number\" value=\""+element.Quantity+"\" ></td>";

                s += "<td data-th=\"Đơn giá\" class=\"td_3\">"+element.Price+" VNĐ</td>";
                s += "<td data-th=\"Tổng tiền\" class=\"td_3\">" + (element.Price * element.Quantity) + " VNĐ</td>";
                s += "</tr>";
                listImagesReturn.Add(s);
            }
            return Json(new
            {
                data = listImagesReturn
            }, JsonRequestBehavior.AllowGet);
        }














    }
}