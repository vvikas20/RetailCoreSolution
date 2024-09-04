using System;
using System.Collections.Generic;

namespace RetailCore.BusinessObjects.BusinessObjects;

public class PermissionType
{
    public Guid PermissionTypeId { get; set; }

    public string PermissionTypeName { get; set; } = null!;

    public string PermissionTypeDisplayName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
