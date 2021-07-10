using BlueModas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Repositories
{

    public interface IProdutoRepository
    {
        Task SaveProdutos(List<Roupa> roupas);
        Task<IList<Produto>> GetProdutos();
    }

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<IList<Produto>> GetProdutos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task SaveProdutos(List<Roupa> roupas)
        {
            foreach (var roupa in roupas)
            {
                if (!await dbSet.Where(p => p.Codigo == roupa.Codigo).AnyAsync())
                {
                    await dbSet.AddAsync(new Produto(roupa.Codigo, roupa.Nome, roupa.Preco));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Roupa
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
