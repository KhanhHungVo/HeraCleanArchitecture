using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Hera.WebApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception err)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                switch(err){
                    case ApplicationException e:
                        response.StatusCode = (int) HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int) HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonConvert.SerializeObject(new {message = err?.Message});
                await response.WriteAsync(result);
                
            }
        } 
    }
}