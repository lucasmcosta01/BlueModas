using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;

        public DataService(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public void InicializaDB()
        {
            contexto.Database.EnsureCreated();
        }
    }
}
