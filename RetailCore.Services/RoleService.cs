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

        public bool DeleteRole(Guid roleId)
        {
            var role = _roleRepository.GetById(roleId);
            if (role != null)
            {
                _roleRepository.Delete(role);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public Role GetRoleById(Guid roleId)
        {
            var role = _roleRepository.GetById(roleId);
            if (role != null)
            {
                return role.ToBusinessObject();
            }
            return null;
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

        public Role UpdateRole(Role role)
        {
            var existingRole = _roleRepository.GetById(role.RoleId);
            if (existingRole != null)
            {
                _roleRepository.Update(role.ToEntityModel(existingRole));
                _unitOfWork.Commit();
                return role;
            }
            return null;
        }
    }
}
