namespace GoodHamburger.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ItemPedido> Itens { get; set; }

        public void CalcularValorTotal()
        {
           ValorTotal = Itens.Sum(n => n.Valor * n.Quantidade);
        }

        public void  AplicarDesconto()
        {
            
                bool v_lanche = Itens.Any(n => n.Id == ItemPedido.XBurger.Id ||
                                              n.Id == ItemPedido.XEgg.Id ||
                                              n.Id == ItemPedido.XBacon.Id);
                bool v_batata = Itens.Any(n => n.Id == ItemPedido.BatataFrita.Id);
                bool v_refri = Itens.Any(n => n.Id == ItemPedido.Refrigerante.Id);
            

            if (v_lanche && v_batata && v_refri)
            {
                ValorTotal *= 0.80m; // 20% de desconto
            }
            else if (v_lanche && v_refri)
            {
                ValorTotal *= 0.85m; // 15% de desconto
            }
            else if (v_lanche && v_batata)
            {
                ValorTotal *= 0.90m; // 10% de desconto
            }

        }
    }
}
