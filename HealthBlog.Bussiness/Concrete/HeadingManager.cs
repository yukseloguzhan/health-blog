using HealthBlog.Bussiness.Abstract;
using HealthBlog.DataAccess.Abstract;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.Concrete
{
    public class HeadingManager : IHeadingService
    {
        /*IHeadingDal headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            this.headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
           return headingDal.Get(x=>x.HeadingId == id);
        }

        public List<Heading> GetHeadingList()
        {
           return headingDal.List();
        }

        public Heading HeadingAdd(Heading entity)
        {
           return headingDal.Add(entity);
        }

        public List<Heading> HeadingListByCategoryId(int id)
        {
            return headingDal.List(x => x.CategoryId == id);
        }

        public void HeadingDelete(Heading entity)
        {
            headingDal.Delete(entity);
        }

        public Heading HeadingUpdate(Heading entity)
        {
           return headingDal.Update(entity);
        }

        public List<Heading> HeadingListByWriterId(int id)
        {
            return headingDal.List(x=>x.WriterId == id);
        }*/
    }
}
