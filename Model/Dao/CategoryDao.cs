using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        OnlineShopDbContext db = null;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.ID;
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString) & x.Status==true);
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }


        public IEnumerable<Category> ListAllPaging( int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories.Where(x=>x.Status==true);
           

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }



        public Category GetByID(long id)
        {
            return db.Categories.Find(id);
        }

        public long Edit(Category category)
        {
            //Xử lý alias

            var ca = db.Categories.Find(category.ID);
            ca.Language = category.Language;
            ca.MetaDescriptions = category.MetaDescriptions;
            ca.MetaKeywords = category.MetaKeywords;
            ca.MetaTitle = category.MetaTitle;
            ca.ModifiedBy = category.ModifiedBy;
            ca.ModifiedDate = category.ModifiedDate;
            ca.Name = category.Name;
            ca.ParentID = category.ParentID;
            ca.SeoTitle = category.SeoTitle;
            ca.ShowOnHome = category.ShowOnHome;
            ca.Status = category.Status;
            //menu. = DateTime.Now;
            db.SaveChanges();

            //Xử lý tag



            return category.ID;
        }
    }
}
