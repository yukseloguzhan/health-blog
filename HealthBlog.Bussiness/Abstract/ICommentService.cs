using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetCommentList();
        Comment CommentAdd(Comment entity);
        Comment GetByID(int id);

        void CommentDelete(Comment entity);
        Comment CommentUpdate(Comment entity);

    }
}
