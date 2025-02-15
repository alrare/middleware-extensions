namespace MyApp.MyAppCustomMiddleware
{
    public class MyAppMiddleware1
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationBuilder _app;

        public MyAppMiddleware1(RequestDelegate next, IApplicationBuilder app)
        {
            _next = next;
            //_app = app;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Custom Middleware 1 - Before\n");
            await _next(context);
            await context.Response.WriteAsync("Custom Middleware 5 - After\n");
        }
    }

    public static class MiddlewareExtensions1
    {
        public static IApplicationBuilder UseCustomMiddleware1(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyAppMiddleware1>(app);
        }
    }
}