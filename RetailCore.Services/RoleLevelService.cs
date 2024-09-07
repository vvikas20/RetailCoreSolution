using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Interfaces.Repository;
using RetailCore.Mapper;
using RetailCore.ServiceContracts;

namespace RetailCore.Services
{
    public class RoleLevelService : IRoleLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IRoleLevelRepository _roleLevelRepository;
        private readonly IRoleLevelPermissionTypeMappingRepository _roleLevelPermissionTypeMappingRepository;

        public RoleLevelService(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IRoleLevelRepository roleLevelRepository, IRoleLevelPermissionTypeMappingRepository roleLevelPermissionTypeMappingRepository)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _roleLevelRepository = roleLevelRepository;
            _roleLevelPermissionTypeMappingRepository = roleLevelPermissionTypeMappingRepository;
        }

        public RoleLevel AddRoleLevel(RoleLevel roleLevel)
        {
            this._roleLevelRepository.Add(roleLevel.ToEntityModel());
            this._unitOfWork.Commit();
            return roleLevel;
        }

        public bool DeleteRoleLevel(Guid roleLevelId)
        {
            var existingRoleLevel = this._roleLevelRepository.GetById(roleLevelId);

            if (existingRoleLevel != null)
            {
                this._roleLevelRepository.Delete(existingRoleLevel);
                this._unitOfWork.Commit();
            }

            return existingRoleLevel != null;
        }

        public RoleLevel GetRoleLevelById(Guid roleLevelId)
        {
            var existingRoleLevel = this._roleLevelRepository.GetById(roleLevelId);
            if (existingRoleLevel != null)
                return existingRoleLevel.ToBusinessObject();
            return null;
        }

        public int GetRoleLevelCount()
        {
            return this._roleLevelRepository.GetAll().Count();
        }

        public IEnumerable<RoleLevel> GetRoleLevels()
        {
            IList<RoleLevel> roleLevels = new List<RoleLevel>();
            foreach (var item in this._roleLevelRepository.GetAll())
            {
                roleLevels.Add(item.ToBusinessObject());
            }
            return roleLevels;
        }

        public RoleLevel UpdateRoleLevel(RoleLevel roleLevel)
        {
            var existingRoleLevel = this._roleLevelRepository.GetById(roleLevel.RoleLevelId);
            if (existingRoleLevel != null)
            {
                this._roleLevelRepository.Update(roleLevel.ToEntityModel(existingRoleLevel));
                this._unitOfWork.Commit();
            }
            return roleLevel;
        }


        public bool AddRoleLevelPermissionTypes(Guid roleLevelId, List<PermissionType> permissionTypes)
        {
            foreach (var item in permissionTypes)
            {
                this._roleLevelPermissionTypeMappingRepository.Add(new Entities.EntityModels.RoleLevelPermissionTypeMapping
                {
                    RoleLevelId = roleLevelId,
                    PermissionTypeId = item.PermissionTypeId,
                    CreatedBy = this._currentUserService.UserId,
                    CreatedDate = DateTime.Now
                });
            }

            return true;
        }


        public bool UpdateRoleLevelPermissionTypes(Guid roleLevelId, List<PermissionType> permissionTypes)
        {
            var existingRoleLevelPermissionMappings = this._roleLevelPermissionTypeMappingRepository.GetMany(x => x.RoleLevelId == roleLevelId);
            foreach (var item in existingRoleLevelPermissionMappings)
            {
                this._roleLevelPermissionTypeMappingRepository.Delete(item);
            }

            foreach (var item in permissionTypes)
            {
                this._roleLevelPermissionTypeMappingRepository.Add(new Entities.EntityModels.RoleLevelPermissionTypeMapping
                {
                    RoleLevelId = roleLevelId,
                    PermissionTypeId = item.PermissionTypeId,
                    CreatedBy = this._currentUserService.UserId,
                    CreatedDate = DateTime.Now
                });
            }

            return true;
        }

        public IEnumerable<Permission> GetRoleLevelPermissions(Guid roleLevelId)
        {
            IList<Permission> permissionTypes = new List<Permission>();
            foreach (var permission in _roleLevelRepository.GetRoleLevelDefaultPermissions(roleLevelId))
            {
                permissionTypes.Add(permission.ToBusinessObject());
            }
            return permissionTypes;
        }
    }
}
