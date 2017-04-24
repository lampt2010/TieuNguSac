using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.EF;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
   public  class SlideDao
    {
        OnlineShopDbContext db = null;
        public SlideDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }

        public IEnumerable<Slide> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
   
        public List<Slide> GetShowRoomHome(int sl)
        {
            return db.Slides.Where(m => m.Type == "Image").Take(sl).ToList();
        }


        public Slide GetByID(int id)
        {
            return db.Slides.Find(id);
        }


        public long Create(Slide content)
        {
            //Xử lý alias
           
            db.Slides.Add(content);
            db.SaveChanges();

         

            return content.ID;
        }

        public long Edit(Slide slide)
        {
            //Xử lý alias

            var ca = db.Slides.Find(slide.ID);
    //        ca.Language = category.Language;
            ca.Image = slide.Image;
            ca.DisplayOrder = slide.DisplayOrder;
            ca.Link = slide.Link;
            ca.ModifiedBy = slide.ModifiedBy;
            ca.ModifiedDate = ca.ModifiedDate;
            ca.Name = slide.Name;
            ca.CreatedBy = slide.CreatedBy;
            ca.CreatedDate = slide.CreatedDate;
            ca.MoreImages = slide.MoreImages;
            ca.Type = slide.Type;
            ca.Description = slide.Description;
            ca.Status = slide.Status;
            //menu. = DateTime.Now;
            db.SaveChanges();

            //Xử lý tag



            return slide.ID;
        }




    }
}
