﻿using HHL.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HHL.ItcastOA.DAL
{
    /// <summary>
    /// 负责创建EF数据操作上下文实例，必须保证线程内唯一.
    /// </summary>
    public class DbContextFactory
    {
      public static DbContext CreateDBContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if(dbContext==null)
            {
                dbContext = new OAEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
       
    }
}
