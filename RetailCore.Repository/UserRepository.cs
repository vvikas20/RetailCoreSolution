using Microsoft.EntityFrameworkCore;
using RetailCore.Entities.EntityModels;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.Context;
using RetailCore.Persistance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Repository
{
	public class UserRepository : Repository<RetailCore.Entities.EntityModels.User>, RetailCore.Interfaces.Repository.IUserRepository
	{
		public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

		public User LoadUserData(Guid currentUser)
		{
			return base.dbset.Include(x => x.Role).Include(x => x.CreatedByNavigation).Include(x => x.ModifiedByNavigation).FirstOrDefault(x => x.UserId == currentUser);
		}
	}
}
