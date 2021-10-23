using HealthBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Entities.Concrete
{
    public class ImageFile : IEntity
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }


        public string ImageDescription { get; set; }

        
        public int ContentId { set; get; }
        public Content Content { set; get; }

    }
}
