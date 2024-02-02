using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<MiddlewareHoraIP>();
//app.UseMiddleware<MiddlewareRequestDurationMilliseconds>();
app.UseMiddleware<MiddlewareRequestDurationMicroseconds>(); 

var exceptionHandler = new MiddlewareExceptionHandling();
exceptionHandler.Configure(app);

app.Run();
