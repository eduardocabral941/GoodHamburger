using GoodHamburger.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {   
        [HttpGet]
        public ActionResult<IEnumerable<ItemPedido>> ObterProdutos()
        {
            var produtos = new List<ItemPedido>
           {
               ItemPedido.XBurger,
               ItemPedido.XEgg,
               ItemPedido.XBacon,
               ItemPedido.BatataFrita,
               ItemPedido.Refrigerante,
           };
            var resultado = produtos.Select(p => new 
            { p.CodProduto,
              p.NomeProduto,
              p.Valor 
            });
           return Ok(resultado);   
        }

        [HttpGet("lanches")]
        public ActionResult<IEnumerable<ItemPedido>> ObterLanches()
        {
            var sanduiches = new List<ItemPedido>
           {
               ItemPedido.XBurger,
               ItemPedido.XEgg,
               ItemPedido.XBacon,
           };
           var resultado = sanduiches.Select(p => new 
            { p.CodProduto,
              p.NomeProduto,
              p.Valor 
            });
           return Ok(resultado);   
        }

        [HttpGet("extras")]
        public ActionResult<IEnumerable<ItemPedido>> ObterExtras()
        {
            var bebidas = new List<ItemPedido>
           {
               ItemPedido.BatataFrita,
               ItemPedido.Refrigerante,             
           };
            var resultado = bebidas.Select(p => new 
                { p.CodProduto,
                  p.NomeProduto,
                  p.Valor 
                });
           return Ok(resultado);   
        }
    }
}
