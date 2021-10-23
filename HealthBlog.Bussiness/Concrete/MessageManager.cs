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
    public class MessageManager : IMessageService
    {

        IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public List<Message> GetInboxList(string p)
        {
            return messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetSendboxList(string p)
        {
            return messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message c)
        {
            messageDal.Add(c);
        }

        public void MessageDelete(Message c)
        {
            messageDal.Delete(c);
        }

        public Message MessageGetByID(int id)
        {
            return messageDal.Get(x => x.MessageId == id);
        }

        public void MessageUpdate(Message c)
        {
            throw new NotImplementedException();
        }
    }
}
