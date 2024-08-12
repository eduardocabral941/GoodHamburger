using GoodHamburger.Models;
using GoodHamburger.Models.DTOs;

namespace GoodHamburger.Services.Interfaces
{
    public interface IPedidoService
    {
        Pedido CriarPedido(List<ItemPedido> itens);
        List<Pedido> ListarPedidos();
        Pedido AtualizarPedido(int id, List<AtualizarItemPedidoDTO> itens);
        bool RemoverPedido(int id);
    }
}
