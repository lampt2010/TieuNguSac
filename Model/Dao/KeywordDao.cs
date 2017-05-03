using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public  class KeywordDao
    {
        OnlineShopDbContext db = null;
        public KeywordDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(Keyword keyword )
        {
            db.Keywords.Add(keyword);
            db.SaveChanges();
            return keyword.Id;
        }
        public List<Keyword> ListAll()
        {
            return db.Keywords.ToList();
        }
        public Keyword ViewDetail(long id)
        {
            return db.Keywords.Find(id);
        }

        public IEnumerable<Keyword> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Keyword> model = db.Keywords;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Value.Contains(searchString) || x.Value.Contains(searchString));
            }

            return model.OrderByDescending(x=>x.Id).ToPagedList(page, pageSize);
        }


        public IEnumerable<Keyword> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Keyword> model = db.Keywords;


            return model.OrderByDescending(x=>x.Id).ToPagedList(page, pageSize);
        }

        public Keyword GetByID(long id)
        {
            return db.Keywords.Find(id);
        }

        public Keyword GetByID(string  value)
        {
            return db.Keywords.Where(x=>x.Value==value).SingleOrDefault();
        }

        public long Edit(Keyword category)
        {
            //Xử lý alias

            var ca = db.Keywords.Find(category.Id);
            ca.Value = category.Value;
            ca.Content = category.Content;
            //menu. = DateTime.Now;
            db.SaveChanges();

            //Xử lý tag



            return category.Id;
        }

    }
}
