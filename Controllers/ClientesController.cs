// Controllers/ClientesController.cs
using LojaApi.Entities;
using LojaApi.Infra.DTOs;
using LojaApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GetAll()
        {
            return Ok(_clienteService.ObterTodos());
        }

        /*[HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            var cliente = _clienteService.ObterPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }*/
        [HttpGet("{id}")]
        public ActionResult<ClienteDetalhadoDto> GetById(int id)
        {
            var clienteDto = _clienteService.ObterDetalhesPorId(id);
            if (clienteDto == null) return NotFound();
            return Ok(clienteDto);
        }

        /*[HttpPost]
        public ActionResult<Cliente> Add(Cliente novoCliente)
        {
            if (string.IsNullOrWhiteSpace(novoCliente.Nome))
            {
                return BadRequest("O nome do cliente é obrigatório.");
            }
            var clienteCriado = _clienteService.Adicionar(novoCliente);
            return CreatedAtAction(nameof(GetById), new { id = clienteCriado.Id }, clienteCriado);
        }*/
        [HttpPost]
        public ActionResult<ClienteDetalhadoDto> Add(CriarClienteDto clienteDto)
        {
            var clienteCriado = _clienteService.Adicionar(clienteDto);
            var dtoRetorno = _clienteService.ObterDetalhesPorId(clienteCriado.Id);
            return CreatedAtAction(nameof(GetById), new { id = clienteCriado.Id }, dtoRetorno);
        }

        [HttpPut("{id}")]
        public ActionResult<Cliente> Update(int id, Cliente clienteAtualizado)
        {
            if (string.IsNullOrWhiteSpace(clienteAtualizado.Nome))
            {
                return BadRequest("O nome do cliente é obrigatório.");
            }
            var cliente = _clienteService.Atualizar(id, clienteAtualizado);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _clienteService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}