using System.Diagnostics;

namespace RetailCore.WebAPI.Middlewares
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class APIRequestLoggerMiddlerware
	{
		const string RequestMessageTemplate =
		   "From {IP} HTTP {RequestMethod} {RequestPath} request recieved";

		const string ResponseMessageTemplate =
		   "From {IP} HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

		private readonly RequestDelegate _next;
		private readonly ILogger<APIRequestLoggerMiddlerware> _logger;

		public APIRequestLoggerMiddlerware(RequestDelegate next, ILogger<APIRequestLoggerMiddlerware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			string ip = $"({httpContext?.Connection.RemoteIpAddress.ToString() ?? "unknown"})";
			_logger.LogInformation(RequestMessageTemplate, ip, httpContext.Request.Method, httpContext.Request.Path);
			var sw = Stopwatch.StartNew();
			try
			{
				await _next(httpContext);
				sw.Stop();
				_logger.LogInformation(ResponseMessageTemplate, ip, httpContext.Request.Method, httpContext.Request.Path, httpContext.Response?.StatusCode, sw.Elapsed.TotalMilliseconds);
			}
			// Never caught, because `LogException()` returns false.
			catch (Exception ex) when (LogException(httpContext, sw, ex)) { }
		}

		bool LogException(HttpContext httpContext, Stopwatch sw, Exception ex)
		{
			sw.Stop();
			var statusCode = httpContext.Response?.StatusCode;
			string ip = $"({httpContext?.Connection.RemoteIpAddress.ToString() ?? "unknown"})";
			_logger.LogError(ex, ResponseMessageTemplate, ip, httpContext.Request.Method, httpContext.Request.Path, statusCode, sw.Elapsed.TotalMilliseconds);

			return false;
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class APIRequestLoggerMiddlerwareExtensions
	{
		public static IApplicationBuilder UseAPIRequestLoggerMiddlerware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<APIRequestLoggerMiddlerware>();
		}
	}
}
