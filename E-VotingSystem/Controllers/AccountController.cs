﻿using E_VotingSystem.Models;
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

        void FncConnectionString()
        {
            l_SqlConnection.ConnectionString = "Data Source=MUHAMMAD-UMAIR\\AISONESQL;Initial Catalog=EVoting;Integrated Security=True";
        }

        [HttpPost]
        public ActionResult Verify(ModUser lModUser)
        {
            FncConnectionString();
            l_SqlConnection.Open();
            l_SqlCommand.Connection = l_SqlConnection;
            l_SqlCommand.CommandText = "SELECT * FROM TBU_USER WHERE MembershipID = @MembershipID AND Password = @Password";
            l_SqlCommand.Parameters.AddWithValue("@MembershipID", lModUser.MembershipID);
            l_SqlCommand.Parameters.AddWithValue("@Password", lModUser.Password);
            l_SqlDataReader = l_SqlCommand.ExecuteReader();
            bool l_MobileFieldEmpty = false;

            if (l_SqlDataReader.Read())
            {
                ModUser l_ModloggedInUser = new ModUser
                {
                    PKGUID = l_SqlDataReader["PKGUID"] as string,
                    MembershipID = l_SqlDataReader["MembershipID"] as string,
                    MemberName = l_SqlDataReader["MemberName"] as string,
                    Address1 = l_SqlDataReader["Address1"] as string,
                    Address2 = l_SqlDataReader["Address2"] as string,
                    Email = l_SqlDataReader["Email"] as string,
                    FounderMembers = l_SqlDataReader["FounderMembers"] as string,
                    LifeAndAnnualMembers = l_SqlDataReader["LifeAndAnnualMembers"] as string,
                    CompanysName = l_SqlDataReader["CompanysName"] as string,
                    Region = l_SqlDataReader["Region"] as string,
                    Password = lModUser.Password, // Set the password from the user input
                    Mobile = l_SqlDataReader["Mobile"] as int?,
                    ContactNo = l_SqlDataReader["ContactNo"] as int?
                };

                if (!l_ModloggedInUser.Mobile.HasValue)
                {
                    l_MobileFieldEmpty = true;
                }
                l_SqlConnection.Close();

                if (l_MobileFieldEmpty)
                {
                    return View("Error");
                }

                return RedirectToAction("Index", "Profile", l_ModloggedInUser);
            }
            else
            {
                l_SqlConnection.Close();
                return View("ErrorPassword"); // Password is incorrect
            }
        }
    }
}
