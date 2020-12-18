using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using CanchaConexion.Models;
using System.Security.Cryptography;

namespace CanchaClienteFinal.Controllers
{
    public class CanchasController : Controller
    {
        // GET: Canchas
        public ActionResult Canchas()
        {
            return View();
        }
    }
}