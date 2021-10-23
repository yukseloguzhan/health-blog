using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.DataAccess.Concrete
{
    public class HealthContext : DbContext
    {
        public DbSet<Category> Categories { set; get; }
        public DbSet<Content> Contents { set; get; }
        
        public DbSet<ImageFile> ImageFiles { set; get; }
        public DbSet<Writer> Writers { set; get; }
        public DbSet<Wrong> Wrongs { set; get; }
        public DbSet<About>  Abouts  { set; get; }
        public DbSet<Message>  Messages  { set; get; }
        public DbSet<Comment>  Comments  { set; get; }
    }
}
