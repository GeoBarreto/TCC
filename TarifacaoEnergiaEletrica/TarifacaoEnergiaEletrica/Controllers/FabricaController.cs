using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifacaoEnergiaEletrica.Models;

namespace TarifacaoEnergiaEletrica.Controllers
{
    public class FabricaController : Controller
    {
        // GET: Fabrica
        public ActionResult CadastroFabrica()
        {
            var fabrica = new Fabrica();
            return View(fabrica);
        }

        [HttpPost]
        public ActionResult CadastroFabrica(Fabrica fabrica)
        {
            if(ModelState.IsValid)
            {
                return View("Resultado", fabrica);
            }
            return View(fabrica);
        }
        
        public ActionResult Resultado(Fabrica fabrica)
        {
            return View(fabrica);
        }
    }
}