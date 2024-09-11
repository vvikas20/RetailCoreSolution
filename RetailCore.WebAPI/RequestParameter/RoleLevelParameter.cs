namespace RetailCore.WebAPI.RequestParameter;

public class RoleLevelParameter
{
	public Guid RoleLevelId { get; set; }

	public string RoleLevelName { get; set; } = null!;

	public string? RoleLevelDisplayName { get; set; }

	public int RoleLevelValue { get; set; }

	public bool? IsDeleted { get; set; }
}