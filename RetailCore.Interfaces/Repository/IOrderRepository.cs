using RetailCore.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Interfaces.Repository
{
    public interface IOrderRepository : IRepository<RetailCore.Entities.EntityModels.Order>
    {

    }
}
