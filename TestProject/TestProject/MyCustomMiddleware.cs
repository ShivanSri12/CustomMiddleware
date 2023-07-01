using System;
namespace TestProject
{
	public class MyCustomMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			await context.Response.WriteAsync("Incoming Request from Custom Middleware \n");
            await next(context);
			await context.Response.WriteAsync("Outgoing Response \n");
        }

	}
}

