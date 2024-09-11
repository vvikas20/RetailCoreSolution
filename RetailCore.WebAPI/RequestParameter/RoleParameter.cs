using System;
using System.Collections.Generic;

namespace RetailCore.WebAPI.RequestParameter;

public class RoleParameter
{
	public Guid RoleId { get; set; }

	public string RoleName { get; set; } = null!;

	public Guid? RoleLevelId { get; set; }

	public bool? IsDeleted { get; set; }
}
