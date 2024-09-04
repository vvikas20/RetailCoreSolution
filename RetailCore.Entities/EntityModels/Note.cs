using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class Note
{
    public Guid NotesId { get; set; }

    public Guid? SeriesId { get; set; }

    public string NotesName { get; set; } = null!;

    public string NotesDisplayName { get; set; } = null!;

    public string? NotesHeader { get; set; }

    public string? NotesBody { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Series? Series { get; set; }
}
