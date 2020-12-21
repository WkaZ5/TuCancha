using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using CanchaConexion.Models;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;
using CanchaClienteFinal.Models;

namespace CanchaClienteFinal.Controllers
{
    public class ReservasController : Controller
    {
        private TuCanchaEntities db = new TuCanchaEntities();
        // GET: Reservas
        public ActionResult Reservas()
        {

            ViewBag.DeportesList = new SelectList(GetDeportesList(), "id_deporte", "nombre");
            ViewBag.RecintosList = new SelectList(GetRecintosList(), "id_recinto", "nombre");

            return View("");

        }       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservas(int? id_deporte, int? id_recinto, String fecha)
        {
            String connectionString = "Server=localhost;Database=TuCancha;User Id=User1;Password=12345;";
            String consulta = "SELECT * FROM canchas WHERE id_cancha NOT IN (SELECT cancha FROM reservas WHERE fecha ='"+ fecha +"') AND recinto = " + id_recinto + " AND deporte = " + id_deporte + " AND estado = 1";      
            Session["fecha"] = fecha;
            List<Selecc> listaa = new List<Selecc>();          
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(consulta, connection);

                var datos = command.ExecuteReader();
                
                while (datos.Read())
                {
                    Selecc seleccionar = new Selecc(); 

                    seleccionar.id= datos.GetInt32(0);
                    seleccionar.nombre = datos.GetString(1);
                    seleccionar.horain = datos.GetTimeSpan(4);

                    listaa.Add(seleccionar);
              
                }       

            }
            Session["lista"]= listaa;
            return Redirect("Seleccion");
        }
        private string CrearBody()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Views/HtmlModelo.html")))
            {
                body = reader.ReadToEnd();
            }
           return body;
        }
        public ActionResult Seleccion()
        {
            ViewBag.Lista = Session["lista"];
            

            return View("");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Seleccion(String rut , int? idcancha)
        {
            String fechareserva = Session["fecha"].ToString();
            String connectionString = "Server=localhost;Database=TuCancha;User Id=User1;Password=12345;";
            String insertar = "INSERT INTO reservas (cliente,cancha,confirmacion,monto_abono,monto_total,metodo_pago,cant_personas,equipo_a,equipo_b,fecha) VALUES ('"+rut+"',"+idcancha+ ",null,null,null,null,null,null,null,'"+fechareserva+"')";
          String conmsultarcliente = "SELECT correo FROM Clientes where rut='" + rut + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(insertar,connection);
                command.ExecuteNonQuery();

                SqlCommand command1 = new SqlCommand(conmsultarcliente, connection);
                var datos = command1.ExecuteReader();

                while (datos.Read())
                {
                    String mail = datos.GetString(0);
                    ViewBag.correo = mail;
                }

                
            }
            

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(ViewBag.correo);
            msg.Subject = Request.Form["Reserva"];
            msg.Body = CrearBody();
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

           


            return View("../Confirmacion/Confirmacion");
        }

        public List<Deportes> GetDeportesList()
        {
            List<Deportes> deporte = db.Deportes.ToList();
            return deporte;
        }
        public List<Recintos> GetRecintosList()
        {
            List<Recintos> recinto = db.Recintos.ToList();
            return recinto;

        }   

    }
}