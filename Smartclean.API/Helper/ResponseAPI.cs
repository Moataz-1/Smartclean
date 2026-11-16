namespace Smartclean.API.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            StatusMessage = message ?? GetMessageFromStatusCode(StatusCode);
        }
        private string GetMessageFromStatusCode(int statuscode)
        {
            return statuscode switch
            {
                200 => "Done",
                400 => "Bad Request",
                401 => "un Authorized",
                404 => "not found resourses",
                500 => "Server Error",
                _ => "Null"
            };
        }
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
    }
}
