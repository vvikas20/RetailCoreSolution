using System;
using System.Collections.Generic;

namespace RetailCore.WebAPI.RequestParameter;

public class ProductCategory
{
	public Guid ProductCategoryId { get; set; }

	public string CategoryName { get; set; } = null!;

	public bool? IsDeleted { get; set; }
}
