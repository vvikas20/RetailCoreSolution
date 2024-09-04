using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class UserSeries
{
    public Guid UserSeriesId { get; set; }

    public Guid UserId { get; set; }

    public Guid SeriesId { get; set; }

    public virtual Series Series { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
