using MikroCrm.Data.Domain.Model;
using MikroCrm.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.Service
{
 public   class BaseService<TEntity> where TEntity:EntityBase
    {
        public GenericUnitOfWork _unit;
        public BaseService()
        {
            _unit = new GenericUnitOfWork();
        }

        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return _unit.Repository<TEntity>().Any(where);
        }

        public bool Delete(List<TEntity> Entity)
        {
            _unit.Repository<TEntity>().Delete(Entity);
            return _unit.SaveChanges();
        }

        public bool Delete(TEntity Entity)
        {
            _unit.Repository<TEntity>().Delete(Entity);
            return _unit.SaveChanges();
        }

        public bool Delete(int Id)
        {
            _unit.Repository<TEntity>().Delete(Id);
            return _unit.SaveChanges();
        }



        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _unit.Repository<TEntity>().Get(where);
        }

        public TEntity GetById(int Id)
        {
            return _unit.Repository<TEntity>().GetById(Id);
        }

        public IList<TEntity> GetList()
        {
            return _unit.Repository<TEntity>().GetList();
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> where)
        {
            return _unit.Repository<TEntity>().GetList(where);
        }

        public TEntity Insert(TEntity Entity)
        {
            _unit.Repository<TEntity>().Insert(Entity);
            _unit.SaveChanges();
            return Entity;
        }

        public bool Update(TEntity Entity)
        {
            _unit.Repository<TEntity>().Update(Entity);
            return _unit.SaveChanges();
        }
        public void Dispose()
        {
            _unit.Dispose(true);

        }
    }
}
