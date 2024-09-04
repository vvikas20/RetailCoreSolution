using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Interfaces.Repository;
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
			_roleRepository.Add(new Entities.EntityModels.Role
			{
				RoleId = role.RoleId,
				RoleName = role.RoleName,
				RoleDisplayName = role.RoleDisplayName,
				RoleLevelId = role.RoleLevelId,
				CreatedBy = role.CreatedBy,
				CreatedDate = role.CreatedDate
			});

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
				roles.Add(new Role
				{
					RoleId = item.RoleId,
					RoleName = item.RoleName,
					RoleDisplayName = item.RoleDisplayName,
					IsActive = item.IsActive,
					CreatedBy = item.CreatedBy,
					CreatedDate = item.CreatedDate,
					ModifiiedBy = item.ModifiiedBy,
					ModifiedDate = item.ModifiedDate
				});
			}

			return roles;
		}
	}
}
