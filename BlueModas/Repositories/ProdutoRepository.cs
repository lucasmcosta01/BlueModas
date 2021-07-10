using BlueModas.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlueModas.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext contexto;

        public ProdutoRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public IList<ProdutoFeminino> GetProdutos()
        {
            return contexto.Set<ProdutoFeminino>().ToList();
        }

        public void SaveProdutos(List<Roupa> roupas)
        {
            foreach (var roupa in roupas)
            {
                contexto.Set<ProdutoFeminino>().Add(new ProdutoFeminino(roupa.Codigo, roupa.Nome, roupa.Preco));
            }
            contexto.SaveChanges();
        }
    }

    public class Roupa
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}