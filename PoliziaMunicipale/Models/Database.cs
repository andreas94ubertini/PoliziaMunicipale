using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PoliziaMunicipale.Models
{
    public class Database
    {
        public static void InsertAnagrafica(string Cognome, string Nome, string Indirizzo, string Citta, string Cap, string Cf)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert INTO Anagrafica VALUES( @Cognome ,@Nome, @Indirizzo, @Citta, @Cap, @Cf)";
            cmd.Parameters.AddWithValue("Cognome", Cognome);
            cmd.Parameters.AddWithValue("Nome", Nome);
            cmd.Parameters.AddWithValue("Indirizzo", Indirizzo);
            cmd.Parameters.AddWithValue("Citta", Citta);
            cmd.Parameters.AddWithValue("Cap", Cap);
            cmd.Parameters.AddWithValue("Cf", Cf);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static List<Violazione> GetViolazioniList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from TipoViolazione", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Violazione> AllViolazioni = new List<Violazione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Violazione violazione = new Violazione();

                violazione.IdViolazione = Convert.ToInt32(sqlDataReader["IdViolazione"]);
                violazione.Descrizione = sqlDataReader["Descrizione"].ToString();

                AllViolazioni.Add(violazione);

            }

            conn.Close();
            return AllViolazioni;
        }
        public static List<Anagrafica> GetAnagraficaList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Anagrafica", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Anagrafica> AllAnagrafica = new List<Anagrafica>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Anagrafica anagrafica = new Anagrafica();

                anagrafica.Id = Convert.ToInt32(sqlDataReader["IdAnagrafica"]);
                anagrafica.Cognome = sqlDataReader["Cognome"].ToString();
                anagrafica.Nome = sqlDataReader["Nome"].ToString();
                anagrafica.Indirizzo = sqlDataReader["Indirizzo"].ToString();
                anagrafica.Citta = sqlDataReader["Citta"].ToString();
                anagrafica.Cap = sqlDataReader["Cap"].ToString();
                anagrafica.Cf = sqlDataReader["Cf"].ToString();

                AllAnagrafica.Add(anagrafica);

            }

            conn.Close();
            return AllAnagrafica;
        }
        public static void AddViolazione(string Descrizione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert INTO TipoViolazione VALUES( @Descrizione)";
            cmd.Parameters.AddWithValue("Descrizione", Descrizione);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void AddVerbale(DateTime dataV, string Indirizzo, string Agente, DateTime DataTrascrizione, double Importo, int Punti, int IdViolazione, int IdAnagrafica )
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert INTO Verbale VALUES( @DataViolazione ,@Indirizzo, @Agente, @DataTrascrizione, @Importo, @Punti, @IdViolazione, @IdAnagrafica)";
            cmd.Parameters.AddWithValue("DataViolazione", dataV);
            cmd.Parameters.AddWithValue("Indirizzo", Indirizzo);
            cmd.Parameters.AddWithValue("Agente",Agente );
            cmd.Parameters.AddWithValue("DataTrascrizione", DataTrascrizione);
            cmd.Parameters.AddWithValue("Importo", Importo);
            cmd.Parameters.AddWithValue("Punti",Punti );
            cmd.Parameters.AddWithValue("IdViolazione",IdViolazione );
            cmd.Parameters.AddWithValue("IdAnagrafica",IdAnagrafica );



            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static List<VerbaliAnagrafica> getPuntiByTrasgressore()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT Anagrafica.idAnagrafica,cognome,nome, SUM(Punti) AS PuntiTotali FROM Verbale "+
                                            "INNER JOIN Anagrafica ON Anagrafica.idAnagrafica = Verbale.idAnagrafica GROUP BY Anagrafica.idAnagrafica, cognome, nome", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<VerbaliAnagrafica> verbaliAnagraficaList = new List<VerbaliAnagrafica>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                VerbaliAnagrafica verbaleV = new VerbaliAnagrafica();
                verbaleV.IdAnagrafica = Convert.ToInt32(sqlDataReader["idAnagrafica"]);
                verbaleV.Cognome = sqlDataReader["cognome"].ToString();
                verbaleV.Nome = sqlDataReader["nome"].ToString();
                verbaleV.PuntiTotali = Convert.ToInt32(sqlDataReader["PuntiTotali"]);
                verbaliAnagraficaList.Add(verbaleV);
            }

            conn.Close();
            return verbaliAnagraficaList;
        }
        public static List<VerbaleTrasgressore> getListGroupedByTrasgressore()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT Anagrafica.idAnagrafica,Cognome,Nome, COUNT(*) AS TotVerbali FROM Verbale INNER JOIN Anagrafica " +
                "ON Anagrafica.idAnagrafica = Verbale.idAnagrafica GROUP BY Anagrafica.idAnagrafica,Cognome,Nome", conn);
            SqlDataReader sqlDataReader;

            conn.Open();
            List<VerbaleTrasgressore> verbaliByT = new List<VerbaleTrasgressore>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                VerbaleTrasgressore v = new VerbaleTrasgressore();
                v.IdAnagrafica = Convert.ToInt32(sqlDataReader["IdAnagrafica"]);
                v.CognomeT = sqlDataReader["Cognome"].ToString();
                v.NomeT = sqlDataReader["Nome"].ToString();
                v.TotVerbali = Convert.ToInt32(sqlDataReader["TotVerbali"]);
                verbaliByT.Add(v);
            }

            conn.Close();
            return verbaliByT;
        }
        public static List<VerbaleMaggiorePunti> getListMaggiorePunti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT Cognome, Nome, DataViolazione, Importo, Punti FROM Verbale INNER JOIN Anagrafica " +
                                            "ON Anagrafica.IdAnagrafica = Verbale.IdAnagrafica WHERE Punti > 10", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<VerbaleMaggiorePunti> ListMaggiore = new List<VerbaleMaggiorePunti>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                VerbaleMaggiorePunti v = new VerbaleMaggiorePunti();
                v.Cognome = sqlDataReader["Cognome"].ToString();
                v.Nome = sqlDataReader["Nome"].ToString();
                v.DataViolazione = Convert.ToDateTime(sqlDataReader["DataViolazione"]);
                v.Importo = Convert.ToDouble(sqlDataReader["Importo"]);
                v.Punti = Convert.ToInt32(sqlDataReader["Punti"]);
                ListMaggiore.Add(v);
            }

            conn.Close();
            return ListMaggiore;
        }
        public static List<VerbaliImporto> getListImporto()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT Cognome, Nome, DataViolazione, Importo, Punti FROM Verbale INNER JOIN Anagrafica " +
                                            "ON Anagrafica.IdAnagrafica = Verbale.IdAnagrafica WHERE Importo > 400", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<VerbaliImporto> listGrouped = new List<VerbaliImporto>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                VerbaliImporto v = new VerbaliImporto();
                v.Cognome = sqlDataReader["Cognome"].ToString();
                v.Nome = sqlDataReader["Nome"].ToString();
                v.DataViolazione = Convert.ToDateTime(sqlDataReader["DataViolazione"]);
                v.Importo = Convert.ToDouble(sqlDataReader["Importo"]);
                v.Punti = Convert.ToInt32(sqlDataReader["Punti"]);
                listGrouped.Add(v);
            }

            conn.Close();
            return listGrouped;
        }

    }
}