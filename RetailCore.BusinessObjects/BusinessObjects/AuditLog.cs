using System;
using System.Collections.Generic;

namespace RetailCore.BusinessObjects.BusinessObjects;

public partial class AuditLog
{
    public Guid AuditLogId { get; set; }

    public string TableName { get; set; } = null!;

    public string Action { get; set; } = null!;

    public Guid RecordId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public DateTime? ActionDate { get; set; }

    public Guid? ActionedBy { get; set; }

    public virtual User? ActionedByNavigation { get; set; }
}
