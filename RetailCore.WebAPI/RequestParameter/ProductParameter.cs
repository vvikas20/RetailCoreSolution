using System;
using System.Collections.Generic;

namespace RetailCore.WebAPI.RequestParameter;

public class ProductParameter
{
	public Guid ProductId { get; set; }

	public string ProductName { get; set; } = null!;

	public string? Description { get; set; }

	public decimal Price { get; set; }

	public int Stock { get; set; }

	public Guid? CategoryId { get; set; }

	public bool? IsDeleted { get; set; }
}
