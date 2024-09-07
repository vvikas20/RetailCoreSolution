using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class RoleLevelPermissionTypeMapping
{
    public Guid Id { get; set; }

    public Guid RoleLevelId { get; set; }

    public Guid PermissionTypeId { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual PermissionType PermissionType { get; set; } = null!;

    public virtual RoleLevel RoleLevel { get; set; } = null!;
}
