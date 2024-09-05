using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class ProductAttributeMapping
{
    public Guid ProductAttributeMappingId { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? ProductAttributeId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ProductAttribute? ProductAttribute { get; set; }
}
