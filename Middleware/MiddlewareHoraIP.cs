using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class MiddlewareHoraIP
{
    private readonly RequestDelegate _next;

    public MiddlewareHoraIP(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Adiciona o cabeçalho personalizado ao contexto da resposta
        context.Response.Headers.Add("X-Custom-Header", $"Hora: {DateTime.Now}, IP: {context.Connection.RemoteIpAddress}");

        // Imprime o horário e o IP na saída do console
        //Console.WriteLine($"Hora: {DateTime.Now}, IP: {context.Connection.RemoteIpAddress}");

        // Chama o próximo middleware no pipeline
        await _next(context);
    }
}
