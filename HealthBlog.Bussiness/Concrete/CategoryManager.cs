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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDal.List();
        }

        public Category CategoryAdd(Category entity)
        {
           return _categoryDal.Add(entity);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public void CategoryDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category CategoryUpdate(Category entity)
        {
           return _categoryDal.Update(entity);
        }

    }
}
