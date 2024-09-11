using System.Runtime.Serialization;

namespace RetailCore.WebAPI.ResponseHandler
{
	[DataContract]
    public class APIResponse
    {
        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public object Result { get; set; }

        [DataMember]
        public ApiError ResponseException { get; set; }

        public APIResponse(int statusCode, string message = "", object result = null, ApiError apiError = null, string apiVersion = "1.0.0.0")
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Result = result;
            this.ResponseException = apiError;
            this.Version = apiVersion;
        }
    }
}
