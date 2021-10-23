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
    public class WriterManager : IWriterService
    {
        IWriterDal writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this.writerDal = writerDal;
        }

        public List<Writer> GetWriterList()
        {
            return writerDal.List();
        }

        public Writer WriterAdd(Writer writer)
        {
            return writerDal.Add(writer);
        }

        public void WriterDelete(Writer entity)
        {
            writerDal.Delete(entity);
        }

        public Writer WriterGetById(int id)
        {
          return  writerDal.Get(x=>x.WriterId == id);
        }

        public Writer WriterUpdate(Writer entity)
        {
           return  writerDal.Update(entity);
        }
    }
}
