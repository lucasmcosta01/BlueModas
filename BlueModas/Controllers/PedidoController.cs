using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Controllers
{
    public class PedidoController : Controller
    {
        public ActionResult Carrossel()
        {
            return View();
        }

        public ActionResult Carrinho(int id)
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Resumo()
        {
            return View();
        }


    }
}
