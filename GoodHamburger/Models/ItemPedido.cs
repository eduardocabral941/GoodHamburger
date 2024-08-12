using System.ComponentModel.DataAnnotations;

namespace GoodHamburger.Models
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public int CodProduto { get; set; } // Teste

        public static readonly ItemPedido XBurger = new ItemPedido {CodProduto = 1, NomeProduto = "X-Burger", Valor = 4.00m };
        public static readonly ItemPedido XEgg = new ItemPedido {CodProduto = 2, NomeProduto = "X-Egg", Valor = 4.50m };
        public static readonly ItemPedido XBacon = new ItemPedido {CodProduto = 3, NomeProduto = "X-Bacon", Valor = 7.00m };
        public static readonly ItemPedido BatataFrita = new ItemPedido {CodProduto = 4, NomeProduto = "Batata Frita", Valor = 2.00m };
        public static readonly ItemPedido Refrigerante = new ItemPedido {CodProduto = 5, NomeProduto = "Refrigerante", Valor = 2.50m };

    }
}
