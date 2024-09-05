using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class WishlistProduct
{
    public Guid WishlistProductId { get; set; }

    public Guid? WishlistId { get; set; }

    public Guid? ProductId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Wishlist? Wishlist { get; set; }
}
