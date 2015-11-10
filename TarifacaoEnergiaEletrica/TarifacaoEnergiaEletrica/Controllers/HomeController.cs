using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifacaoEnergiaEletrica.Models;
using System.Collections;
using System.Net;

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

        public ActionResult CadastroFabrica()
        {
            List<Distribuidora> d = DistribuidoraDAO.ObterInstancia().ObterDistribuidoras();
            ViewBag.distribuidoras = new SelectList(d, "IdDistribuidora", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult CadastroFabrica(Fabrica f)
        {
            int status;
            string idDistribuidora = Request.Form["distribuidoras"].ToString();
            if (idDistribuidora != null)
            {
                f.IdDistribuidora = Convert.ToInt32(idDistribuidora);
                f.IdCliente = Convert.ToInt32(Session["IdCliente"]);
                status = FabricaDAO.ObterInstancia().SalvarFabrica(f);
                if(status == 0)
                {
                    ModelState.AddModelError(string.Empty,"Não foi possivel realizar o cadastro");
                    return RedirectToAction("CadastroFabrica");
                }
                return RedirectToAction("ListaFabricas");
            }
            return View(f);
        }

        [HttpGet]
        public ActionResult EditarFabrica(int? IdFabrica)
        {
            if (IdFabrica == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabrica f = FabricaDAO.ObterInstancia().ObterFabricaPorID(Convert.ToInt32(IdFabrica));
            if (f == null)
            {
                return new HttpNotFoundResult();
            }
            List<Distribuidora> d = DistribuidoraDAO.ObterInstancia().ObterDistribuidoras();
            ViewBag.distribuidoras = new SelectList(d, "IdDistribuidora", "Nome");
            return View(f);
        }

        [HttpPost]
        public ActionResult EditarFabrica(Fabrica f)
        {
            int status;
            string idDistribuidora = Request.Form["distribuidoras"].ToString();
            if (idDistribuidora != null)
            {
                f.IdDistribuidora = Convert.ToInt32(idDistribuidora);
                f.IdCliente = Convert.ToInt32(Session["IdCliente"]);
                status = FabricaDAO.ObterInstancia().AtualizaFabrica(f);
                if (status == 0)
                {
                    ModelState.AddModelError(string.Empty, "Não foi possivel realizar o cadastro");
                    return RedirectToAction("EditarFabrica");
                }
                return RedirectToAction("ListaFabricas");
            }
            return View(f);
        }
    }
}