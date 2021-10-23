using HealthBlog.Bussiness.Abstract;
using HealthBlog.Bussiness.Concrete;
using HealthBlog.DataAccess.Abstract;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule   // global asax a da bir satır yazdım
    {
        public override void Load()
        {
            Kernel.Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Kernel.Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Kernel.Bind<IContentService>().To<ContentManager>().InSingletonScope();
            Kernel.Bind<IContentDal>().To<EfContentDal>().InSingletonScope();

            Kernel.Bind<IAboutService>().To<AboutManager>().InSingletonScope();
            Kernel.Bind<IAboutDal>().To<EfAboutDal>().InSingletonScope();


            Kernel.Bind<IImageFileService>().To<ImageFileManager>().InSingletonScope();
            Kernel.Bind<IImageFileDal>().To<EfImageFileDal>().InSingletonScope();

            Kernel.Bind<ICommentService>().To<CommentManager>().InSingletonScope();
            Kernel.Bind<ICommentDal>().To<EfCommentDal>().InSingletonScope();
        }
    }
}
