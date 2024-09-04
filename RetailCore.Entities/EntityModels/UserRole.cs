using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class UserRole
{
    public Guid UserRoleId { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
