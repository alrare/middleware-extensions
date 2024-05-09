namespace MyApp.MyAppCustomMiddleware
{
    public class MyAppMiddleware2
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationBuilder _app;

        public MyAppMiddleware2(RequestDelegate next, IApplicationBuilder app)
        {
            _next = next;
            //_app = app;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Custom Middleware 2 - Before\n");
            await _next(context);
            await context.Response.WriteAsync("Custom Middleware 4 - After\n");
        }
    }

    public static class MiddlewareExtensions2
    {
        public static IApplicationBuilder UseCustomMiddleware2(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyAppMiddleware2>(app);
        }
    }
}