using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoliziaMunicipale.Models
{
    public class VerbaleTrasgressore
    {
        public int IdAnagrafica { get; set; }
        public string NomeT {  get; set; }
        public string CognomeT {get; set; }
        public int TotVerbali { get; set; }

    }
}