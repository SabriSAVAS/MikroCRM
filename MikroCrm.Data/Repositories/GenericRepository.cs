using MikroCrm.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MikroCrm.Data.Domain.Context;

namespace MikroCrm.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        public GenericRepository(MikroCrmContext context)
        {
            this.Context = context;
        }
        private MikroCrmContext Context;

        public MikroCrmContext context
        {
            get { return Context; }
            set { Context = value; }
        }


        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return Context.Set<TEntity>().Any(where);
        }

        public void Delete(TEntity Entity)
        {
            Context.Set<TEntity>().Remove(Entity);
        }

        public void Delete(List<TEntity> Entities)
        {
            Context.Set<TEntity>().RemoveRange(Entities);
        }

        public void Delete(int id)
        {
            var Entity = GetById(id);
            if (Entity!=null)
            {
                Context.Set<TEntity>().Remove(Entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return Context.Set<TEntity>().FirstOrDefault(where);
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> where)
        {
            return Context.Set<TEntity>().Where(where).OrderByDescending(x => x.Id).ToList();
        }
        public IList<TEntity> GetList()
        {
            return Context.Set<TEntity>().OrderByDescending(x => x.Id).ToList();
        }
        public TEntity Insert(TEntity Entity)
        {
            return Context.Set<TEntity>().Add(Entity);
        }

        public void Update(int id)
        {
            var Entity = GetById(id);
            if (Entity != null)
            {
                Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Update(TEntity Entity)
        {

            Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
