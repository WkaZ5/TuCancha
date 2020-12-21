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
using System.IO;

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
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add(cli.Correo);
                msg.Subject = Request.Form["Registro"];
                msg.Body = CrearBody(cli.Correo,cli.Nombre,cli.Apellido);
                msg.IsBodyHtml = true;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.From = new System.Net.Mail.MailAddress("tucancha.soporte@gmail.com");

                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                cliente.Credentials = new System.Net.NetworkCredential("tucancha.soporte@gmail.com", "1234ASDF");
                cliente.Port = 587;
                cliente.EnableSsl = true;

                cliente.Host = "smtp.gmail.com"; //mail.dominio.com

                try
                {
                    cliente.Send(msg);
                    ViewBag.Message = "Mensaje Enviado correctamente";
                }
                catch (Exception)
                {
                    ViewBag.Message = "Error en enviar el correo intente de nuevo";
                }
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
        private string CrearBody(String correo , String nombre , String apellido )
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Views/HtmlRegis.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("PNombre",nombre+" "+apellido);
            body = body.Replace("Correo", correo);
            

            return body;
        }
    }
    
}