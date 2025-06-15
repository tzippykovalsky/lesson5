namespace Lesson5.Api.Middlewares
{
    public class ShabbatMiddleware(RequestDelegate next)
    {
        //הפונקציות מקושרות אחת לשניה באמצעות רשימה מקושרת
        private readonly RequestDelegate _next = next;

        //הפונקציה מקבלת את אובייקט הבקשה
        public async Task InvokeAsync(HttpContext context)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("The website observes the Sabbath – and does not support its desecration.");
                return;
            }
            await _next(context);

        }
    }
    public static class ShabbatMiddlewareExtensions
    {
        public static IApplicationBuilder UseShabbatMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbatMiddleware>();
        }
    }
}
