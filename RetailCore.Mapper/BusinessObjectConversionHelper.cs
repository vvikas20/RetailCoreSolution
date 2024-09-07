using BusinessObj = RetailCore.BusinessObjects.BusinessObjects;
using EntityObj = RetailCore.Entities.EntityModels;

namespace RetailCore.Mapper
{
    public static class BusinessObjectConversionHelper
    {
        public static Entities.EntityModels.User ToEntityModel(this BusinessObj.User user, Entities.EntityModels.User? existingUserEntity = null)
        {
            var userEntity = existingUserEntity ?? new EntityObj.User();
            userEntity.UserId = user.UserId;
            userEntity.Username = user.Username;
            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.Email = user.Email;
            userEntity.IsDeleted = user.IsDeleted;
            userEntity.RoleId = user.RoleId;
            userEntity.CreatedBy = user.CreatedBy;
            userEntity.CreatedDate = user.CreatedDate;
            userEntity.ModifiedBy = user.ModifiedBy;
            userEntity.ModifiedDate = user.ModifiedDate;
            return userEntity;
        }

        public static Entities.EntityModels.Role ToEntityModel(this BusinessObj.Role role, Entities.EntityModels.Role? existingRoleEntity = null)
        {
            var roleEntity = existingRoleEntity ?? new EntityObj.Role();

            roleEntity.RoleId = role.RoleId;
            roleEntity.RoleName = role.RoleName;
            roleEntity.IsDeleted = role.IsDeleted;
            roleEntity.RoleLevelId = role.RoleLevelId;
            roleEntity.CreatedBy = role.CreatedBy;
            roleEntity.CreatedDate = role.CreatedDate;
            roleEntity.ModifiedBy = role.ModifiedBy;
            roleEntity.ModifiedDate = role.ModifiedDate;

            return roleEntity;

        }

        public static Entities.EntityModels.RoleLevel ToEntityModel(this BusinessObj.RoleLevel roleLevel, Entities.EntityModels.RoleLevel? existingRoleLevel = null)
        {
            var roleLevelEntity = existingRoleLevel ?? new EntityObj.RoleLevel();

            roleLevelEntity.RoleLevelId = roleLevel.RoleLevelId;
            roleLevelEntity.RoleLevelName = roleLevel.RoleLevelName;
            roleLevelEntity.RoleLevelDisplayName = roleLevel.RoleLevelDisplayName;
            roleLevelEntity.RoleLevel1 = roleLevel.RoleLevel1;
            roleLevelEntity.IsDeleted = roleLevel.IsDeleted;
            roleLevelEntity.CreatedBy = roleLevel.CreatedBy;
            roleLevelEntity.CreatedDate = roleLevel.CreatedDate;
            roleLevelEntity.ModifiedBy = roleLevel.ModifiedBy;
            roleLevelEntity.ModifiedDate = roleLevel.ModifiedDate;

            return roleLevelEntity;

        }

        public static Entities.EntityModels.Permission ToEntityModel(this BusinessObj.Permission permission, Entities.EntityModels.Permission? existingPermissionEntity = null)
        {
            var permissionEntity = existingPermissionEntity ?? new EntityObj.Permission();

            permissionEntity.PermissionId = permission.PermissionId;
            permissionEntity.PermissionTypeId = permission.PermissionTypeId;
            permissionEntity.PermissionName = permission.PermissionName;
            permissionEntity.PermissionDisplayName = permission.PermissionDisplayName;
            permissionEntity.IsDeleted = permission.IsDeleted;
            permissionEntity.CreatedBy = permission.CreatedBy;
            permissionEntity.CreatedDate = permission.CreatedDate;
            permissionEntity.ModifiedBy = permission.ModifiedBy;
            permissionEntity.ModifiedDate = permission.ModifiedDate;

            return permissionEntity;

        }

        public static Entities.EntityModels.PermissionType ToEntityModel(this BusinessObj.PermissionType permissionType, Entities.EntityModels.PermissionType? existingPermissionTypeEntity = null)
        {
            var permissionTypeEntity = existingPermissionTypeEntity ?? new EntityObj.PermissionType();

            permissionTypeEntity.PermissionTypeId = permissionType.PermissionTypeId;
            permissionTypeEntity.TypeName = permissionType.TypeName;
            permissionTypeEntity.IsDeleted = permissionType.IsDeleted;
            permissionTypeEntity.CreatedBy = permissionType.CreatedBy;
            permissionTypeEntity.CreatedDate = permissionType.CreatedDate;
            permissionTypeEntity.ModifiedBy = permissionType.ModifiedBy;
            permissionTypeEntity.ModifiedDate = permissionType.ModifiedDate;

            return permissionTypeEntity;

        }

        public static Entities.EntityModels.RoleLevelPermissionTypeMapping ToEntityModel(this BusinessObj.RoleLevelPermissionTypeMapping roleLevelPermissionTypeMapping, Entities.EntityModels.RoleLevelPermissionTypeMapping? existingRoleLevelPermissionTypeMappingEntity = null)
        {
            var roleLevelPermissionTypeMappingEntity = existingRoleLevelPermissionTypeMappingEntity ?? new EntityObj.RoleLevelPermissionTypeMapping();

            roleLevelPermissionTypeMappingEntity.Id = roleLevelPermissionTypeMapping.Id;
            roleLevelPermissionTypeMappingEntity.RoleLevelId = roleLevelPermissionTypeMapping.RoleLevelId;
            roleLevelPermissionTypeMappingEntity.PermissionTypeId = roleLevelPermissionTypeMapping.PermissionTypeId;
            roleLevelPermissionTypeMappingEntity.IsDeleted = roleLevelPermissionTypeMapping.IsDeleted;
            roleLevelPermissionTypeMappingEntity.CreatedBy = roleLevelPermissionTypeMapping.CreatedBy;
            roleLevelPermissionTypeMappingEntity.CreatedDate = roleLevelPermissionTypeMapping.CreatedDate;
            roleLevelPermissionTypeMappingEntity.ModifiedBy = roleLevelPermissionTypeMapping.ModifiedBy;
            roleLevelPermissionTypeMappingEntity.ModifiedDate = roleLevelPermissionTypeMapping.ModifiedDate;

            return roleLevelPermissionTypeMappingEntity;

        }
    }
}
