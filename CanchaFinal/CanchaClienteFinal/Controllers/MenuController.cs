using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using CanchaConexion.Models;
using CanchaClienteFinal.Models;
using System.Security.Cryptography;
namespace CanchaClienteFinal.Controllers
{
    public class MenuController : Controller
    {
        TuCanchaEntities db = new TuCanchaEntities();
        // GET: Menu
        [HttpGet]
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Mision()
        {
            return View();
        }
        public ActionResult Vision()
        {
            return View();
        }


        [HttpPost]

    public ActionResult Verificacion(string rut, string contraseña)
    {
           contraseña = GenerarHash(contraseña);
            
        Clientes cli = db.Clientes.Where(x => x.rut == rut && x.contraseña == contraseña)
            .FirstOrDefault();
        if (cli != null)
        {
            Clienteccf ccc = new Clienteccf();
            ccc.Rut = cli.rut;
            ccc.Contraseña = cli.contraseña;
                   Session["Clientesccf"] = ccc.Rut;
                  return Redirect("/Reservas/Reservas");
                
        }
        else
        {
            ViewBag.error = "Usuario o clave Incorrectos";
            return View("Menu");
        }

    }
        public string GenerarHash(string str)
        {
            byte[] hashArray = Encoding.UTF8.GetBytes(str);
            MD5 md5 = MD5.Create();
            byte[] hashEncripted = md5.ComputeHash(hashArray);

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < hashEncripted.Length; i++)
            {
                sBuilder.Append(hashEncripted[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public ActionResult Verificacion(Clienteccf aa)
    {
        if (ModelState.IsValid)
            return RedirectToAction("Ok");
        else
            return View(aa);
    }

    public ActionResult Ok()
    {
        // Aquí código validación correcta...
        return View();
    }
}
}