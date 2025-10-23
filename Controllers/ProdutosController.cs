using LojaApi.Entities;
using LojaApi.Infra.DTOs;
using LojaApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /*[HttpGet]
        public ActionResult<List<Produto>> GetAll()
        {
            return Ok(_produtoService.ObterTodos());
        }*/
        [HttpGet]
        public ActionResult<List<ProdutoResumoDto>> GetAll()
        {
            return Ok(_produtoService.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = _produtoService.ObterPorId(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Add(Produto novoProduto)
        {
            if (string.IsNullOrWhiteSpace(novoProduto.Nome))
            {
                return BadRequest("O nome do produto é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(novoProduto.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatória.");
            }
            var produtoCriado = _produtoService.Adicionar(novoProduto);
            return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, produtoCriado);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Produto> Update(int id, Produto produtoAtualizado)
        {
            if (string.IsNullOrWhiteSpace(produtoAtualizado.Nome))
            {
                return BadRequest("O nome do produto é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(produtoAtualizado.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatória.");
            }
            var produto = _produtoService.Atualizar(id, produtoAtualizado);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _produtoService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
