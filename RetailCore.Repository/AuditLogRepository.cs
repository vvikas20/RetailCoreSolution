using Microsoft.EntityFrameworkCore;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class AuditLogRepository : Repository<RetailCore.Entities.EntityModels.AuditLog>, RetailCore.Interfaces.Repository.IAuditLogRepository
    {
        public AuditLogRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
