using HHL.ItcastOA.DALFactory;
using HHL.ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HHL.ItcastOA.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IDBSession CurrentDBSession
        {
            get
            {
                //return new DBSession();//暂时
                return DBSessionFactory.CreateDBSession();
            }
        }

        public IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();//子类一定要实现抽象方法。
        }


        public T AddEntities(T entity)
        {
            CurrentDal.AddEntities(entity);
            CurrentDBSession.SaveChanges();
            return entity;
        }

        public bool DeleteEntities(T entity)
        {
            CurrentDal.DeleteEntities(entity);
            return CurrentDBSession.SaveChanges();
        }

        public bool EditEntities(T entity)
        {
            CurrentDal.EditEntities(entity);
           return  CurrentDBSession.SaveChanges();

        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
        }
    }
}
