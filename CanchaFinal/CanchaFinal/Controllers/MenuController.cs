using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using CanchaConexion.Models;
using CanchaFinal.Models;
using System.Security.Cryptography;

namespace CanchaFinal.Controllers
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
        
        [HttpPost]

        public ActionResult Verificacion(string Rut, string Contraseña)
        {
            Administradores admm = db.Administradores.Where(x => x.rut == Rut && x.contraseña == Contraseña)
                .FirstOrDefault();
            if (admm != null)
            {
                Adminn aaa = new Adminn();
                aaa.Rut = admm.rut;
                aaa.Contraseña = admm.contraseña;
                Session["Adminn"] = aaa.Rut;
                return Redirect("/Mantenedor/Index");

            }
            else
            {
                ViewBag.error = "Usuario o clave Incorrectos";
                return Redirect("../Menu/Menu");
            }

        }
        
        public ActionResult Verificacion(Adminn aa)
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
        public ActionResult Mision()
        {
            return View();
        }
        public ActionResult Vision()
        {
            return View();
        }
    }

}