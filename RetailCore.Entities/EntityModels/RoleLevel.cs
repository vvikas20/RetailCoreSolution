using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class RoleLevel
{
    public Guid RoleLevelId { get; set; }

    public string RoleLevelName { get; set; } = null!;

    public string RoleLevelDisplayName { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
