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
    public   class AlbumImageDao
    {
        OnlineShopDbContext db = null;

        public AlbumImageDao()
        {
            db = new OnlineShopDbContext();
        }


        public long Insert(AlbumImage album)
        {
            db.AlbumImages.Add(album);
            db.SaveChanges();
            return album.Id;
        }
        public AlbumImage GetByID(long id)
        {
            return db.AlbumImages.Find(id);
        }

        public  long  Edit (AlbumImage album)
        {
            var al = db.AlbumImages.Find(album.Id);
            al.Name = album.Name;
            al.Status = album.Status;
            al.ViewCount = album.ViewCount;
            al.CreatedDate = album.CreatedDate;
            al.Description = album.Description;
            al.Content = album.Content;
            al.Number = album.Number;
            db.SaveChanges();
            return album.Id;

        }

        public IEnumerable<AlbumImage> ListAllPaging(int page, int pageSize)
        {
            IQueryable<AlbumImage> model = db.AlbumImages;
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public void UpdateImages(long productId, string images,int cout)
        {
            var product = db.AlbumImages.Find(productId);
            product.Content = images;
            product.Number = cout;
            db.SaveChanges();
        }

        public IEnumerable<AlbumImage> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<AlbumImage> model = db.AlbumImages;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString) & x.Status == true);
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }









    }
}
