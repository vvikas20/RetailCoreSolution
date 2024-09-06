using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
    public class OnlinePaymentRepository : Repository<RetailCore.Entities.EntityModels.OnlinePayment>, RetailCore.Interfaces.Repository.IOnlinePaymentRepository
    {
        public OnlinePaymentRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
}
