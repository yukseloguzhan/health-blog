using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetImageFileList();
        List<ImageFile> ImageFileListByContent(int id);
        ImageFile AddImageFile(ImageFile entity);
        ImageFile UpdateImageFile(ImageFile entity);
        void DeleteImageFile(ImageFile entity);
        ImageFile GetImageFile(int id);
    }
}
