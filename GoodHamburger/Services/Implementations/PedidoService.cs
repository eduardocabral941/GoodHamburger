using GoodHamburger.Data;
using GoodHamburger.Models;
using GoodHamburger.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly ApiDbContext _context;

        public PedidoService(ApiDbContext context)
        {
            _context = context;
        }

        public Pedido CriarPedido(List<ItemPedido> itens)
        {
            var produtos = new Dictionary<int, ItemPedido>
            {
                { 1, ItemPedido.XBurger },
                { 2, ItemPedido.XEgg },
                { 3, ItemPedido.XBacon },
                { 4, ItemPedido.BatataFrita },
                { 5, ItemPedido.Refrigerante }
            };
             
            var resultadoValidacao = ValidarPedido(itens);
            if (resultadoValidacao != "Pedido válido")
            {
                throw new InvalidOperationException(resultadoValidacao);
            }

            var itensAgrupados = itens.GroupBy(i => i.CodProduto)
                              .Select(g =>
                              {
                                  var produto = produtos[g.Key];
                                  return new ItemPedido
                                  {
                                      CodProduto = g.Key,
                                      NomeProduto = produto.NomeProduto,
                                      Valor = produto.Valor,
                                      Quantidade = g.Sum(i => i.Quantidade)
                                  };
                              }).ToList();

            var pedido = new Pedido
            {
                Itens = itensAgrupados
            };
            pedido.CalcularValorTotal();
            pedido.AplicarDesconto();

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return pedido;
        }

        public List<Pedido> ListarPedidos()
        {
            return _context.Pedidos.Include(n => n.Itens).ToList();
        }

        public Pedido AtualizarPedido(int id, List<ItemPedido> itens)
        {
            var pedido = _context.Pedidos.Include(p => p.Itens).FirstOrDefault(p => p.PedidoId == id);
            if (pedido == null)
            {
                return null;
            }

            pedido.Itens = itens;
            pedido.CalcularValorTotal();
            _context.SaveChanges();
            return pedido;
        }

        public bool RemoverPedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null)
            {
                return false;
            }

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
            return true;
        }

        public string ValidarPedido(List<ItemPedido> pedido)
        {
            var categorias = new Dictionary<string, List<int>>
            {
                { "sanduiche", new List<int> { 1, 2, 3 } },
                { "batata_frita", new List<int> { 4 } },
                { "refrigerente", new List<int> { 5 } }
            };

            var contacategoria = new Dictionary<string, int>
            {
                { "sanduiche", 0 },
                { "batata_frita", 0 },
                { "refrigerente", 0 }
            };

            foreach(var item in pedido)
            {
                foreach (var categoria in categorias)
                {
                    if (categoria.Value.Contains(item.CodProduto))
                    {
                        contacategoria[categoria.Key] += 1;
                    }
                }
            }

            foreach (var categoria in contacategoria)
            {
                if (categoria.Value > 1)
                {
                    return $"O pedido não pode conter mais de um item da categoria {categoria.Key}";
                }
            }
            return "Pedido válido";
        }
    }
}