using HealthBlog.DataAccess.Abstract;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal  : EfEntityRepositoryBase<Message>, IMessageDal
    {

    }
}
