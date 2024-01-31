using Microsoft.AspNetCore.Mvc;
using ServicoDePagamento.Enum;
using ServicoDePagamento.Interface;
using ServicoDePagamento.ViewModel.Recebivel;
using static ServicoDePagamento.Enum.Enumerador;

namespace ServicoDePagamento.Controllers
{
    [ApiController]
    [Route("v1/recibo/")]
    public class RecebivelController : ControllerBase
    {
        private readonly IRecebivelRepository _recebivelRepository;
        public RecebivelController(IRecebivelRepository recebivelRepository)
        {
            _recebivelRepository = recebivelRepository;
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListarTodosRecibos()
        {
            var recibos = await _recebivelRepository.BuscarTodos();
            return Ok(recibos);
        }

    }
}
