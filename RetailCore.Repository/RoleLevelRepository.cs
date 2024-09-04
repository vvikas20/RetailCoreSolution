using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.Context;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{

	public class RoleLevelRepository : Repository<RetailCore.Entities.EntityModels.RoleLevel>, RetailCore.Interfaces.Repository.IRoleLevelRepository
	{
		public RoleLevelRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
	}
}
