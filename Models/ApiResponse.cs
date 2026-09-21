namespace MinhaPrimeiraApi.Models;
public class ApiResponse<T>
{
    public bool Sucesso { get; set; }
    public T? Dados { get; set; }
    public string? Mensagem { get; set; }

    public static ApiResponse<T> Ok(T dados)
    {
        return new ApiResponse<T>
        {
            Sucesso = true,
            Dados = dados,
            Mensagem = null
        };
    }
 
    public static ApiResponse<T> Erro(string mensagem)
    {
        return new ApiResponse<T>
        {
            Sucesso = false,
            Dados = default,
            Mensagem = mensagem
        };
    }
}