﻿using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class Wishlist
{
    public Guid WishlistId { get; set; }

    public Guid? UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<WishlistProduct> WishlistProducts { get; set; } = new List<WishlistProduct>();
}