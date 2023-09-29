namespace PoliziaMunicipale.Models
{
    public class VerbaliAnagrafica
    {
        public int IdAnagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public int PuntiTotali { get; set; }

        public VerbaliAnagrafica() { }
        public VerbaliAnagrafica(int idAnagrafica, string cognome, string nome, int puntiTotali)
        {
            IdAnagrafica = idAnagrafica;
            Cognome = cognome;
            Nome = nome;
            PuntiTotali = puntiTotali;
        }
    }
}