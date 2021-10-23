using HealthBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Entities.Concrete
{
    public class Comment : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string Mail { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public string FullName { get; set; }  


        public int ContentId { get; set; }
        public virtual Content Content { get; set; }
    }
}
