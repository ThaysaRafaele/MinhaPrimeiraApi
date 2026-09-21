using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Services;

namespace MinhaPrimeiraApi.Controllers;

[ApiController]

[Route("api/[controller]")]

public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;
    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]   
    public async Task<IActionResult> ListarTodos()
    {
        var Produtos = await _service.ListarTodosAsync();
        return Ok(ApiResponse<List<Produto>>.Ok(Produtos));
    }

    [HttpGet("{id}")]   
    public async Task<IActionResult> BuscarPorId(int id)
    {
        if(id <= 0)
        {
            return BadRequest(ApiResponse<Produto>.Erro("O ID deve ser maior que zero."));
        }

        var produto = await _service.BuscarPorIdAsync(id);

         if (produto == null)
        {
            return NotFound(ApiResponse<Produto>.Erro($"Produto com ID {id} não encontrado."));
        }

        return Ok(ApiResponse<Produto>.Ok(produto));
    }

    [HttpPost] 
    public async Task<IActionResult> Criar([FromBody] Produto prod)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<Produto>.Erro("Dados inválidos."));
        }

        var produtoCriado = await _service.CriarAsync(prod);
        return CreatedAtAction(nameof(BuscarPorId), new { id = produtoCriado.Id }, ApiResponse<Produto>.Ok(produtoCriado));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produtoAtualizado)
    {
        if (!ModelState.IsValid)
            return BadRequest(ApiResponse<Produto>.Erro("Dados inválidos."));

        var produto = await _service.AtualizarAsync(id, produtoAtualizado);

        if (produto == null)
            return NotFound(ApiResponse<Produto>.Erro($"Produto com ID {id} não encontrado."));

        return Ok(ApiResponse<Produto>.Ok(produto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var removido = await _service.RemoverAsync(id);
        
        if (!removido)
            return NotFound(ApiResponse<Produto>.Erro($"Produto com ID {id} não encontrado."));

        return Ok(ApiResponse<bool>.Ok(removido));
    }
}