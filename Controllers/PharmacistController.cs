using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MedicationAdministrationSystem.Models;

namespace MedicationAdministrationSystem.Controllers
{
    public class PharmacistController : Controller
    {
        // GET: Pharmacist
        public ActionResult addRoutes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addRoutes(AddRoutes name)
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            dbConnection.Open();
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            //DateTime time = DateTime.Now;
            //string DT = time.ToString("yyyy-MM-dd HH:mm:ss");
            command.CommandText = "Insert into Route(RouteMethod) values('" + name.routeMethods +  "')";
            ViewData["Message"] = "Added successfully!";
            command.ExecuteNonQuery();
            dbConnection.Close();
            ModelState.Clear();
            return View();
        }

        public ActionResult addMedication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addMedication(AddMedicine medicine)
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RCMSConnectionString"].ConnectionString);
            dbConnection.Open();
            string getAllRoutes = "Select routemethod from routes";
            SqlCommand displayRoute = new SqlCommand(getAllRoutes, dbConnection);
            var myRoute = displayRoute.ExecuteScalar();
            ViewBag.myRoutes = new SelectList(myRoute.ToString());


            SqlCommand command = dbConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into Medication(MedicineName, RouteID) values('" + medicine.medicineName + medicine.RouteID+ "')";
            ViewData["Message"] = "Added successfully!";
            command.ExecuteNonQuery();
            dbConnection.Close();
            ModelState.Clear();
            return View();
        }
    }
}