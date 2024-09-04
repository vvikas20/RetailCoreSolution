using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Persistance.DataAccess
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DevelopmentDiaryContext dataContext;
        public IDBContext Get()
        {
            return dataContext ?? (dataContext = new DevelopmentDiaryContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
