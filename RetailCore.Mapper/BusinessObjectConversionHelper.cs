using BusinessObj = RetailCore.BusinessObjects.BusinessObjects;
using EntityObj = RetailCore.Entities.EntityModels;

namespace RetailCore.Mapper
{
	public static class BusinessObjectConversionHelper
	{
		public static Entities.EntityModels.User ToEntityModel(this BusinessObj.User user)
		{
			return new EntityObj.User()
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

		public static Entities.EntityModels.Role ToEntityModel(this BusinessObj.Role role)
		{
			return new EntityObj.Role()
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

		public static Entities.EntityModels.RoleLevel ToEntityModel(this BusinessObj.RoleLevel roleLevel)
		{
			return new EntityObj.RoleLevel()
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
