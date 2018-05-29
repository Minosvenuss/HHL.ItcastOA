using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHL.ItcastOA.IDAL
{
   public interface IBaseDal<T>where T:class,new()
    {
        //查询
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);

        //分页
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc);

        //新增
        T AddEntities(T entity);

        //编辑
        bool EditEntities(T entity);

        //删除
        bool DeleteEntities(T entity);
    }
}
