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
            permissionEntity.PermissionName = permission.PermissionName;
            permissionEntity.IsDeleted = permission.IsDeleted;
            permissionEntity.CreatedBy = permission.CreatedBy;
            permissionEntity.CreatedDate = permission.CreatedDate;
            permissionEntity.ModifiedBy = permission.ModifiedBy;
            permissionEntity.ModifiedDate = permission.ModifiedDate;

            return permissionEntity;

        }
    }
}
