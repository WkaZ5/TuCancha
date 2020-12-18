using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using CanchaConexion.Models;
using System.Security.Cryptography;
using System.IO;

namespace CanchaClienteFinal.Controllers
{
    public class ConfirmacionController : Controller
    {
        // GET: Confirmacion       
    
   public ActionResult Confirmacion()
        {

            return View();
        }


    
    }
}


