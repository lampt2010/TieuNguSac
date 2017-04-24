using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
 public   class SinglePageDao
    {
        OnlineShopDbContext db = null;

        public SinglePageDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(SinglePage single)
        {
            db.SinglePages.Add(single);
            db.SaveChanges();
            return single.Id;
        }

        public List<SinglePage> ListAll()
        {
            return db.SinglePages.Where(x => x.Status == true).ToList();
        }
        public List<SinglePage> ListVideoOther(int id)
        {
            return db.SinglePages.Where(x => x.Status == true & x.Id!=id).ToList();
        }
        public List<SinglePage> ListAllVideo()
        {
            return db.SinglePages.Where(x => x.Status == true& x.Type=="Video").ToList();
        }

        public List<SinglePage> ListByPagging(string type, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            var model = db.SinglePages.Where(x => x.Status == true & x.Type == type).ToList();
            totalRecord = model.Count();
            //var model = (from a in db.Products
            //             join b in db.ProductCategories
            //             on a.CategoryID equals b.ID
            //             where a.CategoryID == categoryID
            //             select new
            //             {
            //                 CateMetaTitle = b.MetaTitle,
            //                 CateName = b.Name,
            //                 CreatedDate = a.CreatedDate,
            //                 ID = a.ID,
            //                 Images = a.Image,
            //                 Name = a.Name,
            //                 MetaTitle = a.MetaTitle,
            //                 Price = a.Price
            //             }).AsEnumerable().Select(x => new ProductViewModel()
            //             {
            //                 CateMetaTitle = x.MetaTitle,
            //                 CateName = x.Name,
            //                 CreatedDate = x.CreatedDate,
            //                 ID = x.ID,
            //                 Images = x.Images,
            //                 Name = x.Name,
            //                 MetaTitle = x.MetaTitle,
            //                 Price = x.Price
            //             });
           

            model.OrderByDescending(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }


        public SinglePage ViewDetail(long id)
        {
            return db.SinglePages.Find(id);
        }

        public IEnumerable<SinglePage> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<SinglePage> model = db.SinglePages;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString) & x.Status == true);
            }

            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }


        public IEnumerable<SinglePage> ListAllPaging(int page, int pageSize)
        {
            IQueryable<SinglePage> model = db.SinglePages.Where(x => x.Status == true);


            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }



        public SinglePage GetByID(long id)
        {
            return db.SinglePages.Find(id);
        }

        public SinglePage Edit(SinglePage model)
        {
            var sg = db.SinglePages.Find(model.Id);
            sg.Lang = model.Lang;
            sg.Name = model.Name;
            sg.MetaTitle = model.MetaTitle;
            sg.Status = model.Status;
            sg.Description = model.Description;
            sg.Content = model.Content;
            sg.Image = model.Image;
            sg.Type = model.Type;
            db.SaveChanges();
            return model;






        }








    }
}
