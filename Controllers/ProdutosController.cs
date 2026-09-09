using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Controllers;

[ApiController]

[Route("api/[controller]")]

public class ProdutosController : ControllerBase
{
    // lista fora dos métodos, acessível por todos
    private static readonly List<Produto> Produtos = new List<Produto>
    {
        new Produto { Id = 1, Nome = "Caderno", Preco = 10.99m },
        new Produto { Id = 2, Nome = "Lápis",      Preco = 1.49m  },
        new Produto { Id = 3, Nome = "Borracha",   Preco = 2.00m  },
        new Produto { Id = 4, Nome = "Caneta",     Preco = 3.50m  },
        new Produto { Id = 5, Nome = "Mochila",    Preco = 89.90m },
        new Produto { Id = 6, Nome = "Estojo",     Preco = 15.00m },
        new Produto { Id = 7, Nome = "Apontador",  Preco = 1.99m  },
        new Produto { Id = 8, Nome = "Régua",      Preco = 2.50m  },
        new Produto { Id = 9, Nome = "Tesoura",    Preco = 8.90m  },
        new Produto { Id = 10, Nome = "Cola",      Preco = 4.00m  },
        // "Caderno", "Lápis", "Borracha", "Caneta", "Mochila",
        // "Estojo", "Apontador", "Régua", "Tesoura", "Cola"
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

        var produto = Produtos.FirstOrDefault(p => p.Id == id);

         if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }

        return Ok(produto);
    }

    [HttpPost] 
    public IActionResult Criar([FromBody] Produto prod)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok($"Produto '{prod.Nome}', '{prod.Preco}' criado com sucesso!");
    }

    // Versão com Model (tema da próxima aula):
    // [HttpPost]
    // public IActionResult Criar([FromBody] Produto produto)
    // {
    //     return Ok(produto);
    // }

}