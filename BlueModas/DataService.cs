using BlueModas.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BlueModas
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto,
                    IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public async Task InicializaDB()
        {
            await contexto.Database.MigrateAsync();

            List<Roupa> roupas = await GetRoupas();

            await produtoRepository.SaveProdutos(roupas);
        }

        private static async Task<List<Roupa>> GetRoupas()
        {

            var json = await File.ReadAllTextAsync("Roupas.json");
            var roupas = JsonConvert.DeserializeObject<List<Roupa>>(json);
            return roupas;
        }
    }
}
