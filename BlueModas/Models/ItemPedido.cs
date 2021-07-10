using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Models
{
    public class ItemPedido : BaseModel
    {
        [Required]
        public Pedido Pedido { get; private set; }
        [Required]
        public ProdutoMasculino ProdutoMasculino { get; internal set; }
        [Required]
        public ProdutoFeminino ProdutoFeminino { get; internal set; }
        [Required]
        public int Quantidade { get; private set; }
        [Required]
        public decimal PrecoUnitario { get; private set; }
        public object ProdutoFeminimo { get; internal set; }

        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, ProdutoMasculino produtoMasculino, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            ProdutoMasculino = produtoMasculino;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
        public ItemPedido(Pedido pedido, ProdutoFeminino produtoFeminino, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            ProdutoFeminino = produtoFeminino;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
    }
}
