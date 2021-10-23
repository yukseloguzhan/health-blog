using HealthBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Entities.Concrete
{
    public class Content : IEntity
    {
        [Key]
        public int ContentId { get; set; }
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public string ContentTitle { get; set; }

        public bool ContentStatus { get; set; } = true;
        public string ContentImage { get; set; } 

       // public int HeadingId { get; set; }  // sileceğiz
       // public virtual Heading Heading { get; set; } // sileceğiz

        public int CategoryId { get; set; }  // ekledik
        public virtual Category  Category { get; set; } // ekledik



        public int? WriterId { get; set; }
        public virtual Writer Writer { set; get; }


        public ICollection<ImageFile> ImageFiles { get; set; }
        public ICollection<Comment> Comments { set; get; }

    }
}
