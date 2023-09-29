using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        // GET: Verbale
        [HttpGet]
        public ActionResult VerbaleIndex()
        {
            List<SelectListItem> listAnagraficaOpt = new List<SelectListItem>();
            List<SelectListItem> listViolazioniOpt = new List<SelectListItem>();
            List<Anagrafica> allAnagrafica = Database.GetAnagraficaList();
            List<Violazione> allViolazioni = Database.GetViolazioniList();
            foreach(Anagrafica a in allAnagrafica)
            {
                SelectListItem item = new SelectListItem { Text = $"{a.Nome} {a.Cognome}", Value = $"{a.Id}" };
                listAnagraficaOpt.Add(item);
            }
            ViewBag.ListAnagraficaOpt = listAnagraficaOpt;
            foreach (Violazione v in allViolazioni)
            {
                SelectListItem item = new SelectListItem { Text = $"{v.Descrizione}", Value = $"{v.IdViolazione}" };
                listViolazioniOpt.Add(item);
            }
            ViewBag.ListViolazioniOpt = listViolazioniOpt;


            return View();
        }
        [HttpPost]
        public ActionResult VerbaleIndex(Verbale v)
        {
            List<SelectListItem> listAnagraficaOpt = new List<SelectListItem>();
            List<SelectListItem> listViolazioniOpt = new List<SelectListItem>();
            List<Anagrafica> allAnagrafica = Database.GetAnagraficaList();
            List<Violazione> allViolazioni = Database.GetViolazioniList();
            foreach (Anagrafica a in allAnagrafica)
            {
                SelectListItem item = new SelectListItem { Text = $"{a.Nome} {a.Cognome}", Value = $"{a.Id}" };
                listAnagraficaOpt.Add(item);
            }
            ViewBag.ListAnagraficaOpt = listAnagraficaOpt;
            foreach (Violazione vi in allViolazioni)
            {
                SelectListItem item = new SelectListItem { Text = $"{vi.Descrizione}", Value = $"{vi.IdViolazione}" };
                listViolazioniOpt.Add(item);
            }
            ViewBag.ListViolazioniOpt = listViolazioniOpt;
            Database.AddVerbale(v.DataViolazione, v.Indirizzo, v.Agente, v.DataTrascrizione, v.Importo, v.Punti, v.IdViolazione, v.IdAnagrafica);
            TempData["Msg"] = "Operazione andata a buon fine!";
            return RedirectToAction("Index", "Home");
        }
    }
}