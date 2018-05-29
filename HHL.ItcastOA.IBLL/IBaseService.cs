using HHL.ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HHL.ItcastOA.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        IDBSession CurrentDBSession { get; }
        IBaseDal<T> CurrentDal { get; set; }
        T AddEntities(T entity);
        bool DeleteEntities(T entity);
        bool EditEntities(T entity);
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc);


    }
}
