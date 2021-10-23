using HealthBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Entities.Concrete
{
    public class Wrong : IEntity
    {
        [Key]
        public int WrongId { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  // migraion yapmadım
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; } = true;

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
