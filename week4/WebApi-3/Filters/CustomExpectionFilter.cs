using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;

            // ✅ Full path ensures creation in project folder
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "logs.txt");

            File.AppendAllText(logPath, $"[{DateTime.Now}] {ex.Message}{Environment.NewLine}");

            context.Result = new ObjectResult("An error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}