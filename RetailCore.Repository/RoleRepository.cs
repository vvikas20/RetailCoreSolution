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

	public class RoleRepository : Repository<RetailCore.Entities.EntityModels.Role>, RetailCore.Interfaces.Repository.IRoleRepository
	{
		public RoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

	}
}
