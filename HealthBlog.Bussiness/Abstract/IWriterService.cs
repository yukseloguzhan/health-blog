using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterList();
        Writer WriterAdd(Writer writer);
        Writer WriterGetById(int id);
        Writer WriterUpdate(Writer entity);
        void WriterDelete(Writer entity);
    }
}
