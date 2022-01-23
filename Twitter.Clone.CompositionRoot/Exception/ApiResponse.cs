﻿namespace Twitter.Clone.CompositionRoot2.Exception
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request",
                401 => "Not Authorize",
                404 => "Resource was not fount",
                500 => "Server error",
                _ => "Bad request"
            };
        }


        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
