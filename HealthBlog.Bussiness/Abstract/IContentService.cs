using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.Abstract
{
    public interface IContentService
    {
        List<Content> GetContentList();
        Content ContentAdd(Content c);
        Content GetByID(int id);

        void ContentDelete(Content c);
        Content ContentUpdate(Content c);
        List<Content> ContentListByCategoryId(int id);
        List<Content> ContentListByTitle(string title);
        Content ContentByCategoryId(int id);
        List<Content> ContentListByWriterId(int id);
        int NumberOfContentByCategory(int id);
    }
}
