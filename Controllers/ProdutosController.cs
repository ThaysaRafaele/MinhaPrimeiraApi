using Microsoft.AspNetCore.Mvc;

namespace MinhaPrimeiraApi.Controllers;

[ApiController]

[Route("api/[controller]")]

public class ProdutosController : ControllerBase
{
    // lista fora dos métodos, acessível por todos
    private static readonly string[] Produtos = new[]
    {
        "Caderno", "Lápis", "Borracha", "Caneta", "Mochila",
        "Estojo", "Apontador", "Régua", "Tesoura", "Cola"
    };

    [HttpGet]   
    public IActionResult ListarTodos()
    {
        return Ok(Produtos);
    }

    [HttpGet("{id}")]   
    public IActionResult BuscarPorId(int id)
    {
        if(id <= 0)
        {
            return BadRequest("O ID deve ser maior que zero.");
        }
        return Ok(Produtos[id - 1]);
    }

    [HttpPost] 
    public IActionResult Criar([FromBody] string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            return BadRequest("O nome do produto não pode estar vazio.");
        }
        return Ok($"Produto '{nome}' criado com sucesso!");
    }

    // Versão com Model (tema da próxima aula):
    // [HttpPost]
    // public IActionResult Criar([FromBody] Produto produto)
    // {
    //     return Ok(produto);
    // }

}