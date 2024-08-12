using GoodHamburger.Models;

namespace GoodHamburger.Services.Interfaces
{
    public interface IPedidoService
    {
        Pedido CriarPedido(List<ItemPedido> itens);
        List<Pedido> ListarPedidos();
        Pedido AtualizarPedido(int id, List<ItemPedido> itens);
        bool RemoverPedido(int id);
    }
}
