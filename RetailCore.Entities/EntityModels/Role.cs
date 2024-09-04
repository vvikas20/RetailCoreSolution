using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class Role
{
    public Guid RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string RoleDisplayName { get; set; } = null!;

    public Guid RoleLevelId { get; set; }

    public bool IsActive { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid? ModifiiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiiedByNavigation { get; set; }

    public virtual RoleLevel RoleLevel { get; set; } = null!;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
