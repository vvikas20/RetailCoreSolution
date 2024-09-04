using System;
using System.Collections.Generic;

namespace RetailCore.BusinessObjects.BusinessObjects;

public class RolePermission
{
    public Guid RolePermissionId { get; set; }

    public Guid RoleId { get; set; }

    public Guid PermissionId { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
