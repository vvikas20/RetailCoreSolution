using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class Permission
{
    public Guid PermissionId { get; set; }

    public string PermissionName { get; set; } = null!;

    public string PermissionDisplayName { get; set; } = null!;

    public Guid PermissionTypeId { get; set; }

    public string PermissionData { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual PermissionType PermissionType { get; set; } = null!;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
