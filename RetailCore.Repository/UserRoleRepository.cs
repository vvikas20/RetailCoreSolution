using Microsoft.EntityFrameworkCore;
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

	public class UserRoleRepository : Repository<RetailCore.Entities.EntityModels.UserRole>, RetailCore.Interfaces.Repository.IUserRoleRepository
	{

		public UserRoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

	}
}
