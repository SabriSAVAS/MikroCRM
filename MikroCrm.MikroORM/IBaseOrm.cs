using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.MikroORM
{
    interface IBaseOrm<TEntity> where TEntity : class
    {
        List<TEntity> GetList();
        List<TEntity> GetList(string sql);
        bool Insert(TEntity Entity);
        bool Update(TEntity Entity);
        bool Delete(int id);
    }
}
