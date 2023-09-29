using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {

        // GET: Anagrafica
        [HttpGet]
        public ActionResult CreateAnagrafica()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAnagrafica(Anagrafica a)
        {
            Database.InsertAnagrafica(a.Cognome, a.Nome, a.Indirizzo, a.Citta, a.Cap, a.Cf);
            TempData["Msg"] = "Operazione andata a buon fine!";
            return RedirectToAction("Index", "Home");
        }
    }
}