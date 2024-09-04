using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Persistance.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private BaseDBContext dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected BaseDBContext DataContext
        {
            get { return dataContext ?? (dataContext =(BaseDBContext) databaseFactory.Get()); }
        }

        public void Commit()
        {
            lock (DataContext)
            {
                DataContext.Commit();
            }

        }
    }
}
