using E_VotingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace E_VotingSystem.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection l_SqlConnection = new SqlConnection();
        SqlCommand l_SqlCommand = new SqlCommand();
        SqlDataReader? l_SqlDataReader;

        // GET: Account
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        void FncConnectionString() {

            l_SqlConnection.ConnectionString = "Data Source=MUHAMMAD-UMAIR\\AISONESQL;Initial Catalog=EVoting;Integrated Security=True";
        }
        [HttpPost]
        public ActionResult Verify( ModUser lModUser ) { 

            FncConnectionString();  
            l_SqlConnection.Open(); 
            l_SqlCommand.Connection= l_SqlConnection;
			l_SqlCommand.CommandText = "select * from TB_USER  where username='" + lModUser.PrUserName + "' and password='" + lModUser.PrPassword + "'";
			l_SqlDataReader = l_SqlCommand.ExecuteReader();

            if (l_SqlDataReader.Read())
            {

                l_SqlConnection.Close();
                return View("Create");
               

            }

            else {

                l_SqlConnection.Close();
                return View("Error");
            }
               
        }
    }
}
