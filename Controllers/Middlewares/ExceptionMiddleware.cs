using System.Net;
using System.Text.Json;
using MinhaPrimeiraApi.Models;
 
namespace MinhaPrimeiraApi.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
 
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ArgumentException ex)
        {
            await EscreverResposta(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception)
        {
            await EscreverResposta(context, HttpStatusCode.InternalServerError,
                "Ocorreu um erro interno. Tente novamente mais tarde.");
        }
    }

    private static async Task EscreverResposta(HttpContext context, HttpStatusCode status, string mensagem)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
 
        var resposta = ApiResponse<object>.Erro(mensagem);
        var json = JsonSerializer.Serialize(resposta, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
 
        await context.Response.WriteAsync(json);
    }

}