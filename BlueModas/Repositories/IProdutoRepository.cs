using BlueModas.Models;
using System.Collections.Generic;

namespace BlueModas.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Roupa> roupas);
        IList<ProdutoFeminino> GetProdutos();
    }
}