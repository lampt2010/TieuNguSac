using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   public class MenuTypeDao
    {
        OnlineShopDbContext db = null;
        public MenuTypeDao()
        {
            db = new OnlineShopDbContext();
        }

     

        public List<MenuType> ListAll()
        {
            return db.MenuTypes.ToList();
        }




        public string GetTypeMenu(int id)
        {
            return db.MenuTypes.Where(x=>x.ID==id).SingleOrDefault().Name;
        }






    }
}
