using BusinessObj = RetailCore.BusinessObjects.BusinessObjects;
using EntityObj = RetailCore.Entities.EntityModels;

namespace RetailCore.Mapper
{
	public static class EntityConversionHelper
	{
		public static BusinessObj.User ToBusinessObject(this Entities.EntityModels.User user)
		{
			return new BusinessObj.User()
			{
				UserId = user.UserId,
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				IsDeleted = user.IsDeleted,
				RoleId = user.RoleId,
				CreatedBy = user.CreatedBy,
				CreatedDate = user.CreatedDate,
				ModifiedBy = user.ModifiedBy,
				ModifiedDate = user.ModifiedDate,
			};
		}

		public static BusinessObj.Role ToBusinessObject(this Entities.EntityModels.Role role)
		{
			return new BusinessObj.Role()
			{
				RoleId = role.RoleId,
				RoleName = role.RoleName,
				IsDeleted = role.IsDeleted,
				RoleLevelId = role.RoleLevelId,
				CreatedBy = role.CreatedBy,
				CreatedDate = role.CreatedDate,
				ModifiedBy = role.ModifiedBy,
				ModifiedDate = role.ModifiedDate,
			};
		}

		public static BusinessObj.RoleLevel ToBusinessObject(this Entities.EntityModels.RoleLevel roleLevel)
		{
			return new BusinessObj.RoleLevel()
			{
				RoleLevelId = roleLevel.RoleLevelId,
				RoleLevelName = roleLevel.RoleLevelName,
				IsDeleted = roleLevel.IsDeleted,
				CreatedBy = roleLevel.CreatedBy,
				CreatedDate = roleLevel.CreatedDate,
				ModifiedBy = roleLevel.ModifiedBy,
				ModifiedDate = roleLevel.ModifiedDate,
			};
		}
	}
}
