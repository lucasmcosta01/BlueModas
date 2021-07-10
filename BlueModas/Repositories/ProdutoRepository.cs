using BlueModas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlueModas.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Roupa> roupas)
        {
            foreach (var roupa in roupas)
            {
                if (!dbSet.Where(p => p.Codigo == roupa.Codigo).Any())
                {
                    dbSet.Add(new Produto(roupa.Codigo, roupa.Nome, roupa.Preco));
                }
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
