using System.Text;

namespace WebAPI_SimpleAuthExample.Auth;
public class SimpleAuthHandler
{
    private readonly RequestDelegate _next;

    public SimpleAuthHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {   
        //Verificar se existe a chave Authorization no header da requisição
        if(!context.Request.Headers.ContainsKey("Authorization"))
        {
            //context.Response.Headers.Add("www-authenticate", "Basic");
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authorization header is missing");
            return;
        }

        //Verificar se a chave Authorization contém o valor correto
        var headerValue = context.Request.Headers["Authorization"].ToString();
        var encondedUsernamePassword = headerValue.Substring(6);
        var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encondedUsernamePassword));
        string[]usernamePassword = decodedUsernamePassword.Split(':');
        var username = usernamePassword[0];
        var password = usernamePassword[1];

        if(username != "admin" || password != "admin")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid username or password");
            return;
        }
        
        await _next(context);
    }
}