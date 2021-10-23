using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.Abstract
{
    public interface IAboutService
    {
        List<About> GetAboutList();
        About AboutAdd(About entity);
        About GetByID(int id);

        void AboutDelete(About entity);
        About AboutUpdate(About entity);
        void AboutContentActive(int id);
        About GetAbout();
    }
}
