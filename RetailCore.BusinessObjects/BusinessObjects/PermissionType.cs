using System;
using System.Collections.Generic;

namespace RetailCore.BusinessObjects.BusinessObjects;

public partial class PermissionType
{
    public Guid PermissionTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
