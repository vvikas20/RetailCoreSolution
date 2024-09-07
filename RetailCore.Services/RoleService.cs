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
        ICurrentUserService _currentUserService;
        IRoleRepository _roleRepository;
        IRoleLevelRepository _roleLevelRepository;
        IRolePermissionRepository _rolePermissionRepository;

        public RoleService(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IRoleRepository roleRepository, IRoleLevelRepository roleLevelRepository, IRolePermissionRepository rolePermissionRepository)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _roleRepository = roleRepository;
            _roleLevelRepository = roleLevelRepository;
            _rolePermissionRepository = rolePermissionRepository;
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

        public bool AssignDefaultPermissionOnRole(Guid roleId)
        {
            var existingRole = _roleRepository.GetById(roleId);
            if (existingRole != null)
            {

                foreach (var permission in _roleLevelRepository.GetRoleLevelDefaultPermissions((Guid)existingRole.RoleLevelId))
                {
                    _rolePermissionRepository.Add(new Entities.EntityModels.RolePermission()
                    {
                        RolePermissionId = Guid.NewGuid(),
                        RoleId = roleId,
                        PermissionId = permission.PermissionId,
                        CreatedBy = _currentUserService.UserId,
                        CreatedDate = DateTime.Now
                    });
                }

                _unitOfWork.Commit();
                return true;
            }

            return false;
        }

        public bool AssignPermissionsToRole(Guid roleId, List<Permission> permissions)
        {
            var existingRole = _roleRepository.GetById(roleId);
            if (existingRole != null)
            {
                _rolePermissionRepository.Delete(x => x.RoleId == roleId);
                foreach (var permission in permissions)
                {
                    _rolePermissionRepository.Add(new Entities.EntityModels.RolePermission()
                    {
                        RolePermissionId = Guid.NewGuid(),
                        RoleId = roleId,
                        PermissionId = permission.PermissionId,
                        CreatedBy = _currentUserService.UserId,
                        CreatedDate = DateTime.Now
                    });
                }

                _unitOfWork.Commit();
                return true;
            }

            return false;
        }

        public IEnumerable<Permission> GetPermissionByRoleId(Guid roleId)
        {
            var existingRolePermissions = _roleRepository.GetPermissionByRoleId(roleId);
            if (existingRolePermissions.Any())
            {
                IList<Permission> permissions = new List<Permission>();
                foreach (var item in existingRolePermissions)
                {
                    var permissionObject = item.ToBusinessObject();
                    permissionObject.PermissionType = item.PermissionType.ToBusinessObject();
                    permissions.Add(permissionObject);
                }
                return permissions;
            }
            return new List<Permission>();
        }
    }
}
