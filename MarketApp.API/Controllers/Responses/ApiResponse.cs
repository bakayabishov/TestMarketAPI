using Microsoft.AspNetCore.Mvc;

namespace MarketApp.API.Controllers.Responses; 

public class ApiResponse {
    public string Type { get; set; }
    public string Message { get; set; }

    public ApiResponse(string type, string message) {
        Type = type;
        Message = message;
    }

    public static ApiResponse Success(string message) {
        return new("success", message);
    }

    public static ApiResponse Error() {
        return new("error", "Произошла ошибка при выполнении операции.");
    }

    public static ApiResponse Error(string message) {
        return new("error", message);
    }

    public static ApiResponse ErrorFull(string message) {
        return new("error", $"Произошла ошибка при выполнении операции: {message}");
    }

    public static ApiResponse Error(ActionContext actionContext) {
        var modelState = actionContext.ModelState;
        var key = modelState.Keys.First();
        if (!key.Contains("$") && modelState.TryGetValue(key, out var value)) {
            return new("error",
                value.Errors.FirstOrDefault()?.ErrorMessage ?? "Ошибка. Введены неверные данные.");
        }

        return new("error", "Ошибка. Введены неверные данные.");
    }
}