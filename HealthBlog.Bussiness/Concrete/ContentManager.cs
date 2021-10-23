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
    public class ContentManager : IContentService
    {
        IContentDal contentDal;

        public ContentManager(IContentDal contentDal)
        {
            this.contentDal = contentDal;
        }

        public Content ContentAdd(Content entity)
        {
           return contentDal.Add(entity);
        }

        public Content ContentByCategoryId(int id)
        {
            var list = contentDal.List(x=>x.CategoryId == id);
            return list.FirstOrDefault();
        }

        public List<Content> ContentListByWriterId(int id)
        {
            return contentDal.List(x=>x.WriterId == id);
            
        }

        public void ContentDelete(Content entity)
        {
            contentDal.Delete(entity);
        }

        public List<Content> ContentListByCategoryId(int id)
        {
            return contentDal.List(x => x.CategoryId == id);
        }

        public Content ContentUpdate(Content entity)
        {
            return  contentDal.Update(entity);         
        }

        public Content GetByID(int id)
        {
            return contentDal.Get(x=>x.ContentId == id);
        }

        public List<Content> GetContentList()
        {
            return contentDal.List();
        }

        public int NumberOfContentByCategory(int id)
        {
            var list = contentDal.List(x=>x.CategoryId == id);

            if (list == null)
            {
                return 0;
            }

            return list.Count();
        }

        public List<Content> ContentListByTitle(string title)
        {
            var list  = contentDal.List(x => x.ContentTitle.Contains(title));
            return list;
        }
    }
}
