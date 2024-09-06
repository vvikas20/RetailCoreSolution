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
        private readonly IRoleLevelRepository _roleLevelRepository;

        public RoleLevelService(IUnitOfWork unitOfWork, IRoleLevelRepository roleLevelRepository)
        {
            _unitOfWork = unitOfWork;
            _roleLevelRepository = roleLevelRepository;
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
    }
}
