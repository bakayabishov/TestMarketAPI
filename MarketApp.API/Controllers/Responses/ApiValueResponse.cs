namespace MarketApp.API.Controllers.Responses; 

public class ApiValueResponse<T> : ApiResponse {
    public T Value { get; set; }

    public ApiValueResponse(string type, string message, T value) : base(type, message) {
        Value = value;
    }

    public static ApiValueResponse<T> Success(string message, T value) {
        return new("success", message, value);
    }

    public static ApiValueResponse<T> Warning(string message, T value) {
        return new("warning", message, value);
    }
}