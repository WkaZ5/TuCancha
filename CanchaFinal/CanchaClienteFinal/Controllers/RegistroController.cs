using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CanchaConexion.Models;
using System.Net;
using System.Data.Entity;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using CanchaClienteFinal.Models;

namespace CanchaClienteFinal.Controllers
{
    public class RegistroController : Controller

    {
        private TuCanchaEntities db = new TuCanchaEntities();
        // GET: Registro
        public ActionResult Registro()
        {
            ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre");
            return View();
        }      
        // POST: Autores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Clienteccf cli)
        {
            if (ModelState.IsValid)
            {
                cli.Contraseña = GenerarHash(cli.Contraseña);
                db.Configuration.ValidateOnSaveEnabled = false;
                Clientes cls = new Clientes
                {
                    rut = cli.Rut,
                    nombre = cli.Nombre,
                    apellido = cli.Apellido,
                    direccion = cli.Direccion,
                    edad = cli.Edad,
                    contraseña = cli.Contraseña,
                    correo = cli.Correo,
                    habilitado = true,
                    comuna = cli.Comuna
                };
                db.Clientes.Add(cls);
                db.SaveChanges();
                return RedirectToAction("../Menu/Menu");
            }

            ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre", cli.Comuna);
            return View();
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
    }
    
}