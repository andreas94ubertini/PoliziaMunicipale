using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GroupByAnagraficaPunti()
        {
            List<VerbaliAnagrafica> VerbaliGroupped= Database.getPuntiByTrasgressore();
            return View(VerbaliGroupped);
        }
        public ActionResult GroupByTotVerbali()
        {
            List<VerbaleTrasgressore> grouped = Database.getListGroupedByTrasgressore();
            return View(grouped);
        }
        public ActionResult GroupByPunti()
        {
           List<VerbaleMaggiorePunti> lista = Database.getListMaggiorePunti();
            return View(lista);
        }
        public ActionResult GroupByImporto()
        {
            
            List<VerbaliImporto> lista = Database.getListImporto();
            return View(lista);
        }


    }
}