using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class MiddlewareRequestDurationMilliseconds
{
    private readonly RequestDelegate _next;

    public MiddlewareRequestDurationMilliseconds(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        Console.WriteLine("Starting stopwatch...");
        stopwatch.Start();

        await _next(context);

        stopwatch.Stop();
        Console.WriteLine($"Stopping stopwatch... Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
