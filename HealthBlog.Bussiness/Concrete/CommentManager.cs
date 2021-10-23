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
    public class CommentManager : ICommentService
    {

        ICommentDal commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal = commentDal;
        }

        public Comment CommentAdd(Comment entity)
        {
            return commentDal.Add(entity);
        }

        public void CommentDelete(Comment entity)
        {
            commentDal.Delete(entity);
        }

        public Comment CommentUpdate(Comment entity)
        {
            return commentDal.Update(entity);
        }

        public Comment GetByID(int id)
        {
            return commentDal.Get(x=>x.ID == id);
        }

        public List<Comment> GetCommentList()
        {
            return commentDal.List();
        }

        public List<Comment> CommentsByContent(int id)
        {
            return commentDal.List(x=>x.Content.ContentId == id);
        }

    }
}
