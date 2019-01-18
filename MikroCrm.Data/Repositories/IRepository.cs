 using MikroCrm.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.Data.Repositories
{
  public  interface IRepository<TEntity> where TEntity:EntityBase
    {
        TEntity Insert(TEntity Entity);
        void Delete(int id);
        void Delete(TEntity Entity);
        void Delete(List<TEntity> Entities);
        void Update(TEntity Entity);
        void Update(int id);

        TEntity GetById(int id);
        IList<TEntity> GetList(Expression<Func<TEntity,bool>> where);
        IList<TEntity> GetList();
        TEntity Get(Expression<Func<TEntity, bool>> where);
        bool Any(Expression<Func<TEntity, bool>> where);

    }
}
