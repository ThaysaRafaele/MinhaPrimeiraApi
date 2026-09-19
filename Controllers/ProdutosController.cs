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
        return Ok(Produtos);
    }

    [HttpGet("{id}")]   
    public async Task<IActionResult> BuscarPorId(int id)
    {
        if(id <= 0)
        {
            return BadRequest("O ID deve ser maior que zero.");
        }

        var produto = await _service.BuscarPorIdAsync(id);

         if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }

        return Ok(produto);
    }

    [HttpPost] 
    public async Task<IActionResult> Criar([FromBody] Produto prod)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var produtoCriado = await _service.CriarAsync(prod);
            return CreatedAtAction(nameof(BuscarPorId), new { id = produtoCriado.Id }, produtoCriado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produtoAtualizado)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var produto = await _service.AtualizarAsync(id, produtoAtualizado);

        if (produto == null)
            return NotFound($"Produto com ID {id} não encontrado.");

        return Ok($"Produto com ID {id} atualizado com sucesso!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var removido = await _service.RemoverAsync(id);
        
        if (!removido)
            return NotFound($"Produto com ID {id} não encontrado.");

        return NoContent();
    }
}