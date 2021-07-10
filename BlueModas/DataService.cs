using BlueModas.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

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

        public void InicializaDB()
        {
            contexto.Database.Migrate();

            List<Roupa> roupas = GetRoupas();

            produtoRepository.SaveProdutos(roupas);
        }

        private static List<Roupa> GetRoupas()
        {
            var json = File.ReadAllText("Roupas.json");
            var roupas = JsonConvert.DeserializeObject<List<Roupa>>(json);
            return roupas;
        }
    }
}
