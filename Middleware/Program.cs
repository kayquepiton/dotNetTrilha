using System;
using System.Threading.Tasks;

namespace ConsoleMiddleware;
class Program{
    static async Task Main(string[] args){
        var middlewarePipeline = new MiddlewarePipeline();

        // Adicionando middlewares
        middlewarePipeline.AddMiddleware(new ChassiMiddleware());
        middlewarePipeline.AddMiddleware(new MotorMiddleware());
        middlewarePipeline.AddMiddleware(new PortasMiddleware());
        middlewarePipeline.AddMiddleware(new PinturaMiddleware());
        middlewarePipeline.AddMiddleware(new InternoMiddleware());

        // Executa o pipeline de middlewares e obtém a string resultante
        string result = await middlewarePipeline.ExecuteAsync();

        // Exibe o resultado
        Console.WriteLine(result);
    }
}

