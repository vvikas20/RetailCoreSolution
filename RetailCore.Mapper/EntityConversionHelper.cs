﻿using BusinessObj = RetailCore.BusinessObjects.BusinessObjects;
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
            roleLevelObj.RoleLevelDisplayName = roleLevel.RoleLevelDisplayName;
            roleLevelObj.RoleLevel1 = roleLevel.RoleLevel1;
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
            permissionObj.PermissionTypeId = permission.PermissionTypeId;
            permissionObj.PermissionName = permission.PermissionName;
            permissionObj.PermissionDisplayName = permission.PermissionDisplayName;
            permissionObj.IsDeleted = permission.IsDeleted;
            permissionObj.CreatedBy = permission.CreatedBy;
            permissionObj.CreatedDate = permission.CreatedDate;
            permissionObj.ModifiedBy = permission.ModifiedBy;
            permissionObj.ModifiedDate = permission.ModifiedDate;

            return permissionObj;
        }

        public static BusinessObj.PermissionType ToBusinessObject(this Entities.EntityModels.PermissionType permissionType, BusinessObj.PermissionType? permissionTypeObject = null)
        {
            var permissionTypeObj = permissionTypeObject ?? new BusinessObj.PermissionType();

            permissionTypeObj.PermissionTypeId = permissionType.PermissionTypeId;
            permissionTypeObj.TypeName = permissionType.TypeName;
            permissionTypeObj.IsDeleted = permissionType.IsDeleted;
            permissionTypeObj.CreatedBy = permissionType.CreatedBy;
            permissionTypeObj.CreatedDate = permissionType.CreatedDate;
            permissionTypeObj.ModifiedBy = permissionType.ModifiedBy;
            permissionTypeObj.ModifiedDate = permissionType.ModifiedDate;

            return permissionTypeObj;
        }

        public static BusinessObj.RoleLevelPermissionTypeMapping ToBusinessObject(this Entities.EntityModels.RoleLevelPermissionTypeMapping roleLevelPermissionTypeMapping, BusinessObj.RoleLevelPermissionTypeMapping? roleLevelPermissionTypeMappingObject = null)
        {
            var roleLevelPermissionTypeMappingObj = roleLevelPermissionTypeMappingObject ?? new BusinessObj.RoleLevelPermissionTypeMapping();

            roleLevelPermissionTypeMappingObj.Id = roleLevelPermissionTypeMapping.Id;
            roleLevelPermissionTypeMappingObj.RoleLevelId = roleLevelPermissionTypeMapping.RoleLevelId;
            roleLevelPermissionTypeMappingObj.PermissionTypeId = roleLevelPermissionTypeMapping.PermissionTypeId;
            roleLevelPermissionTypeMappingObj.IsDeleted = roleLevelPermissionTypeMapping.IsDeleted;
            roleLevelPermissionTypeMappingObj.CreatedBy = roleLevelPermissionTypeMapping.CreatedBy;
            roleLevelPermissionTypeMappingObj.CreatedDate = roleLevelPermissionTypeMapping.CreatedDate;
            roleLevelPermissionTypeMappingObj.ModifiedBy = roleLevelPermissionTypeMapping.ModifiedBy;
            roleLevelPermissionTypeMappingObj.ModifiedDate = roleLevelPermissionTypeMapping.ModifiedDate;

            return roleLevelPermissionTypeMappingObj;
        }

        public static BusinessObj.ProductCategory ToBusinessObject(this Entities.EntityModels.ProductCategory productCategory, BusinessObj.ProductCategory? productCategoryObject = null)
        {
            var productCategoryObj = productCategoryObject ?? new BusinessObj.ProductCategory();

            productCategoryObj.ProductCategoryId = productCategory.ProductCategoryId;
            productCategoryObj.CategoryName = productCategory.CategoryName;
            productCategoryObj.IsDeleted = productCategory.IsDeleted;
            productCategoryObj.CreatedBy = productCategory.CreatedBy;
            productCategoryObj.CreatedDate = productCategory.CreatedDate;
            productCategoryObj.ModifiedBy = productCategory.ModifiedBy;
            productCategoryObj.ModifiedDate = productCategory.ModifiedDate;

            return productCategoryObj;
        }

        public static BusinessObj.Product ToBusinessObject(this Entities.EntityModels.Product product, BusinessObj.Product? productObject = null)
        {
            var productObj = productObject ?? new BusinessObj.Product();

            productObj.ProductId = product.ProductId;
            productObj.ProductName = product.ProductName;
            productObj.Description = product.Description;
            productObj.CategoryId = product.CategoryId;
            productObj.Price = product.Price;
            productObj.Stock = product.Stock;
            productObj.IsDeleted = product.IsDeleted;
            productObj.CreatedBy = product.CreatedBy;
            productObj.CreatedDate = product.CreatedDate;
            productObj.ModifiedBy = product.ModifiedBy;
            productObj.ModifiedDate = product.ModifiedDate;

            return productObj;
        }
    }
}
