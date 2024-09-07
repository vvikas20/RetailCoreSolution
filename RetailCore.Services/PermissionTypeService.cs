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
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public PermissionTypeService(IUnitOfWork unitOfWork, IPermissionTypeRepository permissionTypeRepository)
        {
            this._unitOfWork = unitOfWork;
            this._permissionTypeRepository = permissionTypeRepository;
        }

        public Guid AddPermissionType(PermissionType permissionType)
        {
            this._permissionTypeRepository.Add(permissionType.ToEntityModel());
            this._unitOfWork.Commit();
            return permissionType.PermissionTypeId;
        }

        public List<Guid> AddPermissionTypes(List<PermissionType> permissionTypes)
        {
            foreach (var permissionType in permissionTypes)
            {
                this._permissionTypeRepository.Add(permissionType.ToEntityModel());
            }
            this._unitOfWork.Commit();
            return permissionTypes.Select(x => x.PermissionTypeId).ToList();
        }

        public PermissionType GetPermissionTypeById(Guid permissionTypeId)
        {
            var existingPermissionType = this._permissionTypeRepository.GetById(permissionTypeId);
            if (existingPermissionType != null)
            {
                return existingPermissionType.ToBusinessObject();
            }
            return null;
        }

        public int GetPermissionTypeCount()
        {
            return this._permissionTypeRepository.GetAll().Count();
        }

        public List<PermissionType> GetPermissionTypes()
        {
            return this._permissionTypeRepository.GetAll().Select(x => x.ToBusinessObject()).ToList();
        }
    }
}
