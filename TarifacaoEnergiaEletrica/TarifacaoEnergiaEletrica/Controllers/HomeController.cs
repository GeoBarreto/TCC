using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifacaoEnergiaEletrica.Models;

namespace TarifacaoEnergiaEletrica.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario u)
        {
            Usuario usuario;

            if (ModelState.IsValid)
            {
                usuario = UsuarioDAO.ObterInstancia().Login(u.Email, u.Senha);
                return RedirectToAction("ListaFabricas", usuario);
            }
            return View(u);
        }

        public ActionResult ListaFabricas(Usuario u) {
            return View();
        }
    }
}