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
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public PermissionService(IUnitOfWork unitOfWork, IPermissionRepository permissionRepository, IUserRepository userRepository, IRolePermissionRepository rolePermissionRepository)
        {
            this._unitOfWork = unitOfWork;
            this._permissionRepository = permissionRepository;
            this._userRepository = userRepository;
            this._rolePermissionRepository = rolePermissionRepository;
        }

        public Permission AddPermission(Permission permission)
        {
            this._permissionRepository.Add(permission.ToEntityModel());
            this._unitOfWork.Commit();
            return permission;
        }

        public bool DeletePermission(Guid permissionId)
        {
            var existingPermission = this._permissionRepository.GetById(permissionId);
            if (existingPermission != null)
            {
                this._permissionRepository.Delete(existingPermission);
                this._unitOfWork.Commit();
                return true;
            }

            return false;
        }

        public Permission GetPermissionById(Guid permissionId)
        {
            var permission = this._permissionRepository.GetById(permissionId);
            if (permission != null)
            {
                return permission.ToBusinessObject();
            }

            return null;
        }

        public int GetPermissionCount()
        {
            return this._permissionRepository.GetAll().Count();
        }

        public IEnumerable<Permission> GetPermissions()
        {
            IEnumerable<Permission> permissions = new List<Permission>();
            foreach (var permission in this._permissionRepository.GetAll())
            {
                permissions.Append(permission.ToBusinessObject());
            }
            return permissions;
        }

        public IEnumerable<Permission> GetUserPermissions(Guid userId)
        {
            IEnumerable<Permission> permissions = new List<Permission>();
            var user = this._userRepository.GetById(userId);
            if (user != null)
            {
                var rolePermissions = this._rolePermissionRepository.GetMany(r => r.RoleId == user.RoleId);
                if (rolePermissions != null)
                {
                    foreach (var rolePermission in rolePermissions)
                    {
                        var permission = this._permissionRepository.GetById(rolePermission.PermissionId.Value);
                        if (permission != null)
                        {
                            permissions.Append(permission.ToBusinessObject());
                        }
                    }
                    return permissions;
                }
            }

            return permissions;
        }

        public Permission UpdatePermission(Permission permission)
        {
            var existingPermission = this._permissionRepository.GetById(permission.PermissionId);
            if (existingPermission != null)
            {

                this._permissionRepository.Update(permission.ToEntityModel(existingPermission));
                this._unitOfWork.Commit();
                return permission;
            }

            return null;
        }
    }
}
