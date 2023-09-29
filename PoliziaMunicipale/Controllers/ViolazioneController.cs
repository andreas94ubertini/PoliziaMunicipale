using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class ViolazioneController : Controller
    {
        // GET: Violazione
        public ActionResult ViolazioniIndex()
        {
            List<Violazione> AllViolazioni = Database.GetViolazioniList();
            return View(AllViolazioni);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Violazione v)
        {
            Database.AddViolazione(v.Descrizione);
            TempData["Msg"] = "Operazione andata a buon fine!";
            return RedirectToAction("ViolazioniIndex");
        }
    }
}