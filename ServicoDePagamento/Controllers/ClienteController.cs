using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicoDePagamento.Interface;
using ServicoDePagamento.Models;
using ServicoDePagamento.ViewModel.Clientes;

namespace ServicoDePagamento.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase 
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IBus _bus;
        public ClienteController(IClienteRepository clienteRepository, IBus bus)
        {
            _bus = bus;
            _clienteRepository = clienteRepository;   
        }

        [HttpPost("v1/cliente/add")]
        public async Task<IActionResult> AdicionarCliente([FromBody] ClienteViewModel clienteViewModel )
        {
            try
            {
                if (clienteViewModel == null) return NotFound("Insira os dados corretamente!!");
                var validacao = await _clienteRepository.ValidarCliente(clienteViewModel.Documento);
                if (validacao == true) return BadRequest("Já existe uma conta com esse documento");

                var Cliente = new Cliente { Nome = clienteViewModel.Nome, Documento = clienteViewModel.Documento, Cep = clienteViewModel.Cep };                
                await _clienteRepository.Adicionar(Cliente);
                await _clienteRepository.Commit();

                var eventRequest = new ClienteEvent(Cliente.Nome,Cliente.Documento,Cliente.Id);
                await _bus.Publish(eventRequest);

                return Ok(Cliente);
            }
            catch(DbUpdateException ex)
            {
                return StatusCode(500,"Não foi possivel adicionar cliente");
            }
            catch (Exception ex)
            {
                return StatusCode(500,"Erro interno!!");
            }
        }

        [HttpGet("v1/cliente/ListAll")]
        public async Task<IActionResult> ListarTodosClientes()
        {
            try
            {
                var clientes = await _clienteRepository.BuscarTodos();
                if (clientes == null) return NotFound("Não há clientes");
                return Ok(clientes);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpGet("v1/cliente/list/{Id:int}")]
        public async Task<IActionResult> ListarPorId([FromRoute] int Id)
        {
            var cliente = await _clienteRepository.BuscarPorId(Id);
            if (cliente == null) return NotFound("Cliente não encontrado!!");
            return Ok(cliente);
        }

        [HttpPut("v1/cliente/att")]
        public async Task<IActionResult> AtualizarDadosCliente([FromBody] AtualizarClienteViewModel atualizarCliente)
        {
            try
            {
                var cliente = await _clienteRepository.BuscarPorId(atualizarCliente.Id);
                if (cliente == null) return NotFound("usuario não encontrado");

                cliente.Nome = atualizarCliente.Nome;
                cliente.Cep = atualizarCliente.Cep;

                await _clienteRepository.Atualizar(cliente);
                await _clienteRepository.Commit();
                return Ok(cliente);
            }
            catch(DbUpdateException ex)
            {
                return StatusCode(500, "Não foi possivel atualizar dados");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno");
            }
            
        }

        [HttpDelete("v1/cliente/delete/{Id:int}")]
        public async Task<IActionResult> RemoverCliente([FromRoute] int Id)
        {
            try
            {
                var cliente = await _clienteRepository.BuscarPorId(Id);
                if (cliente == null) return NotFound("Usuario não encontrado");

                await _clienteRepository.Remover(Id);
                await _clienteRepository.Commit();
                return Ok("usuario removido!!");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Não foi possivel remover usuario");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpGet("v1/cliente/saldoconsulta/{Id:int}")]
        public async Task<IActionResult> consultarSaldo([FromRoute] int Id)
        {
            try
            {
                var usuario = await _clienteRepository.BuscarPorId(Id);
                if (usuario == null) return NotFound("Cliente não encontrado");

                var SaldoDiponivel = await _clienteRepository.ConsultarSaldoDisponivel(Id);

                var SaldoPendente = await _clienteRepository.ConsultarSaldoAReceber(Id);
                
                return Ok($"Saldo disponivel: {SaldoDiponivel} \nSaldo Pendente: {SaldoPendente}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno");
            }
        }

    }
}
