﻿using HHL.ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HHL.ItcastOA.DALFactory
{
    public class DBSessionFactory
    {
        public static IDBSession CreateDBSession()
        {
            IDBSession dbSession =(IDBSession) CallContext.GetData("dbSession");
            if(dbSession==null)
            {
                dbSession = new DBSession();
                CallContext.SetData("dbSession", dbSession);
            }
            return dbSession;
        }
    }
}
