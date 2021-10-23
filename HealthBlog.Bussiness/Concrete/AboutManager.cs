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
    public class AboutManager : IAboutService
    {
        IAboutDal aboutDal;

        public AboutManager(IAboutDal _aboutDal)
        {
            aboutDal = _aboutDal;
        }

        public About AboutAdd(About entity)
        {
           return aboutDal.Add(entity);
        }

        public void AboutContentActive(int id)
        {
            var list = aboutDal.List();
            foreach (var x in list)
            {
                if(x.Id != id)
                {
                    x.Status = false;
                }
                else
                {
                    x.Status = true;
                }

                aboutDal.Update(x);
               
            }

           
        }

        public void AboutDelete(About entity)
        {
            aboutDal.Delete(entity);
        }

        public About AboutUpdate(About entity)
        {
            return aboutDal.Update(entity);
        }

        public About GetAbout()
        {
            var list = aboutDal.List(x=>x.Status==true).OrderByDescending(x=>x.CreatedDate);
            var about = list.FirstOrDefault();
            return about;
        }

        public List<About> GetAboutList()
        {
            return aboutDal.List();
        }

        public About GetByID(int id)
        {
            return aboutDal.Get(x=>x.Id == id);
        }
    }
}
