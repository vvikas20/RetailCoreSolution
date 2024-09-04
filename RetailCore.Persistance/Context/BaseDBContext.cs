using Microsoft.EntityFrameworkCore;
using RetailCore.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Persistance.Context
{
    public abstract class BaseDBContext : DbContext, IDBContext
    {
        protected BaseDBContext()
        {
        }

        public BaseDBContext(DbContextOptions options) : base(options)
        {
        }

        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
