namespace RetailCore.WebAPI.ResponseHandler;

public class ApiError
{
	public bool IsError { get; set; }
	public string ExceptionMessage { get; set; }
	public string Details { get; set; }
	public string ReferenceErrorCode { get; set; }
	public string ReferenceDocumentLink { get; set; }
	public IEnumerable<ValidationError> ValidationErrors { get; set; }

	public ApiError()
	{
		this.IsError = true;
	}

	public ApiError(string message)
	{
		this.ExceptionMessage = message;
		this.IsError = true;
	}

}