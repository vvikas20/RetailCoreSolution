using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Interfaces.Repository;
using RetailCore.Mapper;
using RetailCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Services
{
	public class RoleService : IRoleService
	{
		IUnitOfWork _unitOfWork;
		IRoleRepository _roleRepository;

		public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
		{
			_unitOfWork = unitOfWork;
			_roleRepository = roleRepository;
		}

		public Role AddRole(Role role)
		{
			_roleRepository.Add(role.ToEntityModel());
			_unitOfWork.Commit();

			return role;
		}

		public int GetRoleCount()
		{
			return this._roleRepository.GetAll().Count();
		}

		public IEnumerable<Role> GetRoles()
		{
			IList<Role> roles = new List<Role>();

			foreach (var item in _roleRepository.GetAll())
			{
				roles.Add(item.ToBusinessObject());
			}

			return roles;
		}
	}
}
