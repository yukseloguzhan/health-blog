using HealthBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Entities.Concrete
{
    public class Writer : IEntity
    {
        [Key]
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
        public string WriterImage { get; set; }
        public string WriterAbout { get; set; }
        [StringLength(200)]
        public string WriterMail { get; set; }
        [StringLength(200)]
        public string WriterPassword { get; set; }
        [StringLength(50)]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; } = true;


        //public ICollection<Heading> Headings { get; set; } // sleceğiz
        public ICollection<Content> Contents { get; set; }
    }
}
