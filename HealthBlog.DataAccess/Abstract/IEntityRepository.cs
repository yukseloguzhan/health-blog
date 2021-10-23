﻿using HealthBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> List(Expression<Func<T, bool>> filter = null);  // isterse filtre vermeyebilir
        T Add(T k);
        T Update(T k);
        void Delete(T k);
        T Get(Expression<Func<T, bool>> filter);



    }
}
