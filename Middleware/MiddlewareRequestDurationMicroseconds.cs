using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class MiddlewareRequestDurationMicroseconds
{
    private readonly RequestDelegate _next;

    public MiddlewareRequestDurationMicroseconds(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        await _next(context);

        stopwatch.Stop();
        Console.WriteLine($"Request took: {stopwatch.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L))} microseconds\n");
    }
}
