using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RetailCore.WebAPI.ResponseHandler;
using System.Net;

namespace KCC.CustomerPortal.API.Middlewares
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class APIResponseWrapperMiddleware
	{
		private readonly RequestDelegate _next;

		public APIResponseWrapperMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			if (IsSwagger(context))
				await this._next(context);
			else
			{
				var originalBodyStream = context.Response.Body;

				using (var responseBody = new MemoryStream())
				{
					context.Response.Body = responseBody;

					try
					{
						await _next.Invoke(context);

						context.Response.Body = responseBody;

						if (context.Response.StatusCode == (int)HttpStatusCode.OK)
						{
							var responseBodyText = await FormatResponse(responseBody);
							await HandleSuccessRequestAsync(context, responseBodyText, context.Response.StatusCode);
						}
						else
						{
							await HandleNotSuccessRequestAsync(context, context.Response.StatusCode);
						}
					}
					catch (System.Exception ex)
					{
						await HandleExceptionAsync(context, ex);
					}
					finally
					{
						responseBody.Seek(0, SeekOrigin.Begin);
						await responseBody.CopyToAsync(originalBodyStream);
					}
				}
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, System.Exception exception)
		{
			ApiError apiError = null;
			APIResponse apiResponse = null;
			int code = 0;

			if (exception is ApiException)
			{
				var ex = exception as ApiException;
				apiError = new ApiError(ex.Message);
				apiError.ValidationErrors = ex.Errors;
				apiError.ReferenceErrorCode = ex.ReferenceErrorCode;
				apiError.ReferenceDocumentLink = ex.ReferenceDocumentLink;
				code = ex.StatusCode;
				context.Response.StatusCode = code;

			}
			else if (exception is UnauthorizedAccessException)
			{
				apiError = new ApiError("Unauthorized Access");
				code = (int)HttpStatusCode.Unauthorized;
				context.Response.StatusCode = code;
			}
			else
			{
#if !DEBUG
            var msg = "An unhandled error occurred.";
            string stack = null;
#else
				var msg = exception.GetBaseException().Message;
				string stack = exception.StackTrace;
#endif

				apiError = new ApiError(msg);
				apiError.Details = stack;
				code = (int)HttpStatusCode.InternalServerError;
				context.Response.StatusCode = code;
			}

			context.Response.ContentType = "application/json";

			apiResponse = new APIResponse
						  (code, ResponseMessageEnum.Exception.GetEnumDescription(), null, apiError);

			var json = JsonConvert.SerializeObject(apiResponse, new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});

			context.Response.Body.SetLength(0);
			return context.Response.WriteAsync(json);
		}

		private static Task HandleNotSuccessRequestAsync(HttpContext context, int code)
		{
			context.Response.ContentType = "application/json";

			ApiError apiError = null;
			APIResponse apiResponse = null;

			if (code == (int)HttpStatusCode.NotFound)
				apiError = new ApiError("The specified URI does not exist. Please verify and try again.");
			else if (code == (int)HttpStatusCode.NoContent)
				apiError = new ApiError("The specified URI does not contain any content.");
			else
				apiError = new ApiError("Your request cannot be processed. Please contact a support.");

			apiResponse = new APIResponse
						  (code, ResponseMessageEnum.Failure.GetEnumDescription(), null, apiError);
			context.Response.StatusCode = code;

			var json = JsonConvert.SerializeObject(apiResponse, new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});

			context.Response.Body.SetLength(0);
			return context.Response.WriteAsync(json);
		}

		private static Task HandleSuccessRequestAsync(HttpContext context, object body, int code)
		{
			context.Response.ContentType = "application/json";
			string jsonString, bodyText = string.Empty;
			APIResponse apiResponse = null;

			if (!body.ToString().IsValidJson())
				bodyText = JsonConvert.SerializeObject(body);
			else
				bodyText = body.ToString();

			dynamic bodyContent = JsonConvert.DeserializeObject<dynamic>(bodyText);
			Type type = bodyContent?.GetType();

			if (type.Equals(typeof(Newtonsoft.Json.Linq.JObject)))
				apiResponse = JsonConvert.DeserializeObject<APIResponse>(bodyText);

			//We are receiving APIResponse from the action here
			if (apiResponse != null)
			{
				if (apiResponse.StatusCode != code)
					context.Response.StatusCode = apiResponse.StatusCode;
			}
			else
			{
				apiResponse = new APIResponse(code, ResponseMessageEnum.Success.GetEnumDescription(), bodyContent, null);
			}

			jsonString = JsonConvert.SerializeObject(apiResponse, new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});

			context.Response.Body.SetLength(0);
			return context.Response.WriteAsync(jsonString);
		}

		private async Task<string> FormatResponse(MemoryStream responseBody)
		{
			responseBody.Seek(0, SeekOrigin.Begin);
			var plainBodyText = await new StreamReader(responseBody).ReadToEndAsync();
			responseBody.Seek(0, SeekOrigin.Begin);

			return plainBodyText;
		}

		private bool IsSwagger(HttpContext context)
		{
			return context.Request.Path.StartsWithSegments("/swagger");
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class APIResponseWrapperMiddlewareExtensions
	{
		public static IApplicationBuilder UseAPIResponseWrapperMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<APIResponseWrapperMiddleware>();
		}
	}
}
