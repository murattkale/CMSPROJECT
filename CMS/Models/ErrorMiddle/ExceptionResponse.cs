using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.ErrorMiddle
{
    public class ExceptionResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ExceptionResponse(string message, int statusCode = 500)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string message = "";
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            message = ex.ToString();
        }

        if (!context.Response.HasStarted)
        {
            //context.Response.ContentType = "application/json";
            //var response = new ExceptionModel(message);
            //var json = JsonConvert.SerializeObject(message);
            await context.Response.WriteAsync(message);
        }
    }
}

// Extension method ile IApplicationBuilder altına custom methodumuzu eklenmesini sağlıyoruz.
public static class ErrorMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorWrappingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorMiddleware>();
    }
}
