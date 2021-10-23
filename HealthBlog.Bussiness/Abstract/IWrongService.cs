using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.Abstract
{
    public interface IWrongService
    {
       List<Wrong> GetWrongList();
       Wrong GetByID(int id);
       Wrong WrongUpdate(Wrong entity);
       Wrong AddWrong(Wrong entity);
       void DeleteWrong(Wrong entity);
    }
}
