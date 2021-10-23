using HealthBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Entities.Concrete
{
    public class Message  : IEntity
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string MessageContent { get; set; }
        public string Subject { get; set; }
        public DateTime MessageDate { get; set; }
        public string NameAndSurname { get; set; }
    }
}
