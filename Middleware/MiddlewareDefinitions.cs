using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMiddleware;

// Interface para middleware
public interface IMiddleware
{
    Task<string> Invoke();
}

// Classe para representar o pipeline de middlewares
public class MiddlewarePipeline
{
    private readonly List<IMiddleware> _middlewares;

    public MiddlewarePipeline()
    {
        _middlewares = new List<IMiddleware>();
    }

    // Método para adicionar middlewares ao pipeline
    public void AddMiddleware(IMiddleware middleware)
    {
        _middlewares.Add(middleware);
    }

    // Método para executar os middlewares e obter a string resultante
    public async Task<string> ExecuteAsync()
    {
        StringBuilder stringBuilder = new StringBuilder();

        // Executa cada middleware na ordem em que foram adicionados
        foreach (var middleware in _middlewares)
        {
            // Obtém a string retornada pelo middleware e adiciona ao StringBuilder
            string result = await middleware.Invoke();
            stringBuilder.Append(result);
        }

        return stringBuilder.ToString();
    }
}

// Classe para middleware Chassi
public class ChassiMiddleware : IMiddleware
{
    public async Task<string> Invoke()
    {
        return "Chassi";
    }
}

// Classe para middleware Motor
public class MotorMiddleware : IMiddleware
{
    public async Task<string> Invoke()
    {
        return "Motor";
    }
}

// Classe para middleware Portas
public class PortasMiddleware : IMiddleware
{
    public async Task<string> Invoke()
    {
        return "Portas";
    }
}

// Classe para middleware Pintura
public class PinturaMiddleware : IMiddleware
{
    public async Task<string> Invoke()
    {
        return "Pintura";
    }
}

// Classe para middleware Interno
public class InternoMiddleware : IMiddleware
{
    public async Task<string> Invoke()
    {
        return "Interno";
    }
}

