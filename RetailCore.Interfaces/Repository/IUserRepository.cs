using RetailCore.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Interfaces.Repository
{
	public interface IUserRepository : IRepository<RetailCore.Entities.EntityModels.User>
	{
		RetailCore.Entities.EntityModels.User LoadUserData(Guid currentUser);
	}
}
