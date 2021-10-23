using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {

    }
}
