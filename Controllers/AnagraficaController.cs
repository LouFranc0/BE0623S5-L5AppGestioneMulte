using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5_ProgettoPolizia.Models;

namespace S5_ProgettoPolizia.Controllers
{
    public class AnagraficaController : Controller
    {
        private string connString = "Server=localhost,1433;Database=ESERCIZIOS2L5; User Id=sa;Password=NotHunter2; Initial Catalog=ESERCIZIOS2L5; Integrated Security=true; TrustServerCertificate=True";

        [HttpGet]
        public IActionResult AggiungiAnagrafica()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiAnagrafica(string surname, string name, string address, string city, int CAP, string CodiceFiscale)
        {
            var conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Città, CAP, CodiceFiscale) VALUES (@surname, @name, @address, @city, @CAP, @CodiceFiscale)", conn);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@CAP", CAP);
                cmd.Parameters.AddWithValue("@CodiceFiscale", CodiceFiscale);
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            finally { conn.Close(); }
        }
    }
}
