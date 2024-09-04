using System;
using System.Collections.Generic;

namespace RetailCore.BusinessObjects.BusinessObjects;

public class UserRole
{
    public Guid UserRoleId { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
