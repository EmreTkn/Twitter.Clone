namespace Twitter.Clone.WebApi.Errors;
public class ApiResponse
{
    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            200 => "Success.",
            400 => "Bad request.",
            401 => "Something went wrong during the authentication process.Please try signing in again",
            404 => "Not found",
            500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change (:",
            _ => null

        };
    }
}