namespace Lesson5.Api.Middlewares
{
    public class ShabbatMiddleware(RequestDelegate next)
    {
        //הפונקציות מקושרות אחת לשניה באמצעות רשימה מקושרת
        private readonly RequestDelegate _next = next;

        //הפונקציה מקבלת את אובייקט הבקשה
        public async Task InvokeAsync(HttpContext context)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("האתר שומר שבת- ואינו נותן יד למחלליה");
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
