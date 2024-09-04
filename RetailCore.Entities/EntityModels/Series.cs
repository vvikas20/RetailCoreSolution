using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class Series
{
    public Guid SeriesId { get; set; }

    public string SeriesName { get; set; } = null!;

    public string SeriesDisplayName { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<UserSeries> UserSeries { get; set; } = new List<UserSeries>();
}
