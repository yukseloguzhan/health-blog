using HealthBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Entities.Concrete
{
    public class Category : IEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } = true;


        //public ICollection<Heading> Headings { set; get; }  // sileceğiz
        public ICollection<Content>  Contents { set; get; }   // ekledik


    }
}
