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
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario u)
        {
            if (ModelState.IsValid)
            {
                Usuario autenticado = UsuarioDAO.ObterInstancia().Login(u.Email, u.Senha);

                if (autenticado != null)
                {
                    Session["NomeUsuario"] = autenticado.Nome;
                    Session["IdCliente"] = autenticado.IdCliente;
                    return RedirectToAction("ListaFabricas");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario ou Senha invalidos!");
                    return View(u);
                }
            }
            return View(u);
        }
        
        public ActionResult ListaFabricas()
        {
            List<Fabrica> fabricas = FabricaDAO.ObterInstancia().ObterFabricasPorCliente(Convert.ToInt32(Session["IdCliente"]));
            return View(fabricas);
        }
    }
}