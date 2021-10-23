using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.Abstract
{
    public interface IMessageService
    {
        List<Message> GetInboxList(string p);
        List<Message> GetSendboxList(string p);
        void MessageAdd(Message c);
        Message MessageGetByID(int id);

        void MessageDelete(Message c);
        void MessageUpdate(Message c);
    }
}
