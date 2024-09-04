using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Interfaces.Repository;
using RetailCore.ServiceContracts;

namespace RetailCore.Services
{
	public class RoleLevelService : IRoleLevelService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRoleLevelRepository _roleLevelRepository;

		public RoleLevelService(IUnitOfWork unitOfWork, IRoleLevelRepository roleLevelRepository)
		{
			_unitOfWork = unitOfWork;
			_roleLevelRepository = roleLevelRepository;
		}

		public RoleLevel AddRoleLevel(RoleLevel roleLevel)
		{
			this._roleLevelRepository.Add(new Entities.EntityModels.RoleLevel
			{
				RoleLevelId = roleLevel.RoleLevelId,
				RoleLevelName = roleLevel.RoleLevelName,
				RoleLevelDisplayName = roleLevel.RoleLevelDisplayName,
				CreatedBy = roleLevel.CreatedBy,
				CreatedOn = roleLevel.CreatedOn,
			});
			this._unitOfWork.Commit();
			return roleLevel;
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
				roleLevels.Add(new RoleLevel
				{
					RoleLevelId = item.RoleLevelId,
					RoleLevelName = item.RoleLevelName,
					RoleLevelDisplayName = item.RoleLevelDisplayName,
					CreatedBy = item.CreatedBy,
					CreatedOn = item.CreatedOn,
					ModifiedBy = item.ModifiedBy,
					ModifiedOn = item.ModifiedOn,
				});
			}
			return roleLevels;
		}
	}
}
