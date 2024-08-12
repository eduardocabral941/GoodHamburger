using GoodHamburger.Models;
using GoodHamburger.Models.DTOs;
using GoodHamburger.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public IActionResult EnviarPedido([FromBody] List<ItemPedidoDTO> itemIds)
        {
            try
            {
                var itens = itemIds.Select(i => new ItemPedido
                {
                    CodProduto = i.ProductCode,
                    Quantidade = i.Quantidade
                }).ToList();

                var pedido = _pedidoService.CriarPedido(itens);
                return Ok(new { pedido.PedidoId, pedido.ValorTotal });
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { erro = e.Message });
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { erro = e.Message });
            }
        }

        [HttpGet]
        public IActionResult ListarPedidos()
        {
            if(!_pedidoService.ListarPedidos().Any())
            {
                return NotFound(new { erro = "Nenhum pedido encontrado" });
            }
            var pedidos = _pedidoService.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpPut("{id:int}")]
        public IActionResult AtualizarPedido(int id, [FromBody] List<AtualizarItemPedidoDTO> itemDtos)
        {
            try
            {
                var pedido = _pedidoService.AtualizarPedido(id, itemDtos);
                if (pedido == null)
                {
                    return NotFound(new { erro = "Pedido não encontrado" });
                }

                return Ok(new { pedido.PedidoId, pedido.ValorTotal });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoverPedido(int id)
        {
            var sucesso = _pedidoService.RemoverPedido(id);
            if (!sucesso)
            {
                return NotFound(new { erro = "Pedido não encontrado" });
            }

            return Ok(new { mensagem = "Pedido removido com sucesso" });
        }
    }
}
