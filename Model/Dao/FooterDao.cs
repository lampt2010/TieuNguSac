using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FooterDao
    {
        OnlineShopDbContext db = null;
        public FooterDao()
        {
            db = new OnlineShopDbContext();
        }

        public int Create(Footer footer)
        {
            db.Footers.Add(footer);
            db.SaveChanges();
            return footer.ID;
        }
        public Footer GetFooter()
        {
            return db.Footers.FirstOrDefault(x => x.Status == true& x.Type=="Footer");
        }

        public Footer GetAddress()
        {
            return db.Footers.FirstOrDefault(x => x.Status == true & x.Type == "Address");
        }

        public Footer GetMap()
        {
            return db.Footers.FirstOrDefault(x => x.Status == true & x.Type == "Map");
        }





        public IEnumerable<Footer> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Footer> model = db.Footers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Content.Contains(searchString) || x.Content.Contains(searchString));
            }

            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public Footer GetByID(int id)
        {
            return db.Footers.Find(id);
        }

        public long Edit(Footer footer)
        {
            //Xử lý alias

            var foo = db.Footers.Find(footer.ID);
            foo.Name = footer.Name;
            foo.Status = footer.Status;
            foo.Type = footer.Type;
            foo.Content = footer.Content;




            //menu. = DateTime.Now;
            db.SaveChanges();

            //Xử lý tag



            return footer.ID;
        }

    }
}
