using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifacaoEnergiaEletrica.Models;
using System.Collections;

namespace TarifacaoEnergiaEletrica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario u)
        {
            if (ModelState.IsValid)
            {
                Usuario autenticado = UsuarioDAO.ObterInstancia().Login(u.Email, u.Senha);
                Session["NomeUsuario"] = autenticado.Nome;
                return RedirectToAction("ListaFabrica", autenticado);
            }
            return View();
        }

        public class FabricaController : Controller
        {
            // GET: Fabrica
            public ActionResult ListaFabricas(Usuario u)
            {
                ArrayList fabricas = FabricaDAO.ObterInstancia().ObterFabricasPorCliente(u.IdCliente);
                ViewData["fabricas"] = fabricas;
                return View();
            }
        }
    }
}