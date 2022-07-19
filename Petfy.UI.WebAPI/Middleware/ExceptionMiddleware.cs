using Petfy.UI.WebAPI.Errors;
using System.Net;
using System.Text.Json;

namespace Petfy.UI.WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //Log the original exception
                _logger.LogError(ex, ex.Message);

                //Set the contentType and the statusCode of the response
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                //Create a response wether is development or production
                var response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal Server Error");

                //Create JsonSerialzerOptions
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                //Serialize the response to json using the options
                var json = JsonSerializer.Serialize(response, options);

                //Writes the json into the context
                await context.Response.WriteAsync(json);
            }
        }
    }
}
