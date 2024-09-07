using System;
using System.Collections.Generic;

namespace RetailCore.BusinessObjects.BusinessObjects;

public partial class RoleLevel
{
    public Guid RoleLevelId { get; set; }

    public string RoleLevelName { get; set; } = null!;

    public string? RoleLevelDisplayName { get; set; }

    public int RoleLevel1 { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<RoleLevelPermissionTypeMapping> RoleLevelPermissionTypeMappings { get; set; } = new List<RoleLevelPermissionTypeMapping>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
