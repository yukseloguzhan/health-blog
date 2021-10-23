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
    public class ImageFileManager : IImageFileService
    {

        IImageFileDal imageFileDal;

        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            this.imageFileDal = ımageFileDal;
        }

        public ImageFile AddImageFile(ImageFile entity)
        {
           return imageFileDal.Add(entity);
        }

        public void DeleteImageFile(ImageFile entity)
        {
            imageFileDal.Delete(entity);
        }

        public ImageFile GetImageFile(int id)
        {       
            return  imageFileDal.Get(x=>x.ImageId == id);
    
        }

        public List<ImageFile> GetImageFileList()
        {
            return imageFileDal.List();
        }

        public List<ImageFile> ImageFileListByContent(int id)
        {
            return imageFileDal.List(x=>x.ContentId == id);
        }

        public ImageFile UpdateImageFile(ImageFile entity)
        {
            return imageFileDal.Update(entity);
        }
    }
}