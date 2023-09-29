using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PoliziaMunicipale.Models
{
    public class Anagrafica
    {
        public int Id { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Cap {  get; set; }
        [Display(Name = "Codice Fiscale")]
        public string Cf { get; set; }
    }
}