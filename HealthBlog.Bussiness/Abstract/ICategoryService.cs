using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        Category CategoryAdd(Category entity);
        Category GetByID(int id);

        void CategoryDelete(Category entity);
        Category CategoryUpdate(Category entity);

    }
}
