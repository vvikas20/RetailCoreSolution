using BusinessObj = RetailCore.BusinessObjects.BusinessObjects;
using EntityObj = RetailCore.Entities.EntityModels;

namespace RetailCore.Mapper
{
    public static class EntityConversionHelper
    {
        public static BusinessObj.User ToBusinessObject(this Entities.EntityModels.User user, BusinessObj.User? userObject = null)
        {
            var userObj = userObject ?? new BusinessObj.User();

            userObj.UserId = user.UserId;
            userObj.Username = user.Username;
            userObj.FirstName = user.FirstName;
            userObj.LastName = user.LastName;
            userObj.Email = user.Email;
            userObj.IsDeleted = user.IsDeleted;
            userObj.RoleId = user.RoleId;
            userObj.CreatedBy = user.CreatedBy;
            userObj.CreatedDate = user.CreatedDate;
            userObj.ModifiedBy = user.ModifiedBy;
            userObj.ModifiedDate = user.ModifiedDate;

            return userObj;

        }

        public static BusinessObj.Role ToBusinessObject(this Entities.EntityModels.Role role, BusinessObj.Role? roleObject = null)
        {
            var roleObj = roleObject ?? new BusinessObj.Role();

            roleObj.RoleId = role.RoleId;
            roleObj.RoleName = role.RoleName;
            roleObj.IsDeleted = role.IsDeleted;
            roleObj.RoleLevelId = role.RoleLevelId;
            roleObj.CreatedBy = role.CreatedBy;
            roleObj.CreatedDate = role.CreatedDate;
            roleObj.ModifiedBy = role.ModifiedBy;
            roleObj.ModifiedDate = role.ModifiedDate;

            return roleObj;
        }

        public static BusinessObj.RoleLevel ToBusinessObject(this Entities.EntityModels.RoleLevel roleLevel, BusinessObj.RoleLevel? roleLevelObject = null)
        {
            var roleLevelObj = roleLevelObject ?? new BusinessObj.RoleLevel();

            roleLevelObj.RoleLevelId = roleLevel.RoleLevelId;
            roleLevelObj.RoleLevelName = roleLevel.RoleLevelName;
            roleLevelObj.IsDeleted = roleLevel.IsDeleted;
            roleLevelObj.CreatedBy = roleLevel.CreatedBy;
            roleLevelObj.CreatedDate = roleLevel.CreatedDate;
            roleLevelObj.ModifiedBy = roleLevel.ModifiedBy;
            roleLevelObj.ModifiedDate = roleLevel.ModifiedDate;

            return roleLevelObj;
        }

        public static BusinessObj.Permission ToBusinessObject(this Entities.EntityModels.Permission permission, BusinessObj.Permission? permissionObject = null)
        {
            var permissionObj = permissionObject ?? new BusinessObj.Permission();

            permissionObj.PermissionId = permission.PermissionId;
            permissionObj.PermissionName = permission.PermissionName;
            permissionObj.IsDeleted = permission.IsDeleted;
            permissionObj.CreatedBy = permission.CreatedBy;
            permissionObj.CreatedDate = permission.CreatedDate;
            permissionObj.ModifiedBy = permission.ModifiedBy;
            permissionObj.ModifiedDate = permission.ModifiedDate;

            return permissionObj;
        }
    }
}
