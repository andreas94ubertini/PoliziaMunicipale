using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PoliziaMunicipale.Models
{
    public class Verbale
    { 
        public int IdVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string Indirizzo { get; set; }
        public string Agente { get; set; }
        public DateTime DataTrascrizione { get; set; }
        public double Importo { get; set; }
        public int Punti {  get; set; }
        [Display(Name = "Tipo di infrazione")]
        public int IdViolazione { get; set; }
        [Display(Name = "Destinatario verbale")]
        public int IdAnagrafica {  get; set; }
    }
}