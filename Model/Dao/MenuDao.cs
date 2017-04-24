using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        OnlineShopDbContext db = null;
        public MenuDao()
        {
            db = new OnlineShopDbContext();
        }

        public int Create(Menu menu)
        {
            db.Menus.Add(menu);
            db.SaveChanges();



            return menu.ID;
        }


        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }

        public Menu GetByID(int Id)
        {
            return db.Menus.Find(Id);
        }


        public Menu GetMenuLast()
        {
            var list= db.Menus.OrderByDescending(x => x.ID).ToList();
            return list[0];
        }

        public int Level(int Id,int parentId)
        {
            string level = db.Menus.Where(x => x.Status == true & x.ParentId == parentId & x.ID == Id).SingleOrDefault().Level;
            return level.Length/5;
        }

        public string Level(int Id)
        {
            return db.Menus.Where(x => x.ID == Id).Single().Level;
        }

       



        public IEnumerable<Menu> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Menu> model = db.Menus;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Text.Contains(searchString) || x.Text.Contains(searchString));
            }

            return model.OrderBy(x => x.Level).ToPagedList(page, pageSize);
        }

        public List<Menu> ListAll()
        {
            return db.Menus.OrderBy(x=>x.Level).ToList();
        }


        public long Edit(Menu menu)
        {
            //Xử lý alias
            var mn = db.Menus.Find(menu.ID);
            mn.ParentId = menu.ParentId;
            mn.Link = menu.Link;
            mn.Level = menu.Level;
            mn.Status = menu.Status;
            mn.Text = menu.Text;
            mn.TypeID = menu.TypeID;
            mn.DisplayOrder = menu.DisplayOrder;
            mn.Target = menu.Target;

            //menu. = DateTime.Now;
            db.SaveChanges();

            //Xử lý tag
          
            

            return menu.ID;
        }





    }
}
