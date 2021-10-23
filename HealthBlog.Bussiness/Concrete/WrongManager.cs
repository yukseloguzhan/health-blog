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
    public class WrongManager : IWrongService
    {
        IWrongDal wrongDal;

        public WrongManager(IWrongDal wrongDal)
        {
            this.wrongDal = wrongDal;
        }

        public Wrong AddWrong(Wrong entity)
        {
            return wrongDal.Add(entity);
        }

        public void DeleteWrong(Wrong entity)
        {         
            wrongDal.Delete(entity);
        }

        public Wrong GetByID(int id)
        {
            return wrongDal.Get(x=>x.WrongId == id);
        }

        public List<Wrong> GetWrongList()
        {
            return wrongDal.List();
        }

        public Wrong WrongUpdate(Wrong entity)
        {
            return wrongDal.Update(entity);
        }
    }
}
