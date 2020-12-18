using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CanchaConexion.Models;
using CanchaFinal.Models;
using System.Net;
using System.Data.Entity;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace CanchaFinal.Controllers
{
    public class ClientesController : Controller
    {
        private TuCanchaEntities db = new TuCanchaEntities();
        // GET: Clientes
        public ActionResult Clientes()
        {
            if (Session["Adminn"] != null)
            {
                var cli = db.Clientes.Include(u => u.Comunas);
                return View(cli.ToList());
            }
            else
            {
                return View("../Menu/Menu");
            }
        }

        
        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Details(string rut)
        {
            if (Session["Adminn"] != null)
            {
                if (rut == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Clientes ccl = db.Clientes.Find(rut);
                if (ccl == null)
                {
                    return HttpNotFound();
                }
                return View(ccl);
            }
            else
            {
                return View("../Menu/Menu");
            }
            
        }

        public ActionResult Edit(string rut)
        {
            if (Session["Adminn"] != null)
            {
                if (rut == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Clientes cll = db.Clientes.Find(rut);
                Session["rut"] = rut;
                if (cll == null)
                {
                    return HttpNotFound();
                }
                ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre", cll.comuna);
                return View(cll);

            }
            else
            {
                return View("../Menu/Menu");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteEdit cll)
        {
            if (Session["Adminn"] != null)
            {
                Clientes ccc = db.Clientes.Find(Session["rut"].ToString());
                ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre", ccc.comuna);

                if (ModelState.IsValid)
                {
                    string rut = Session["rut"].ToString();
                    db.Configuration.ValidateOnSaveEnabled = false;
                    Clientes clie = db.Clientes.FirstOrDefault(x => x.rut == rut);
                    clie.nombre = cll.nombre;
                    clie.apellido = cll.apellido;
                    clie.direccion = cll.direccion;
                    clie.edad = cll.edad;
                    clie.correo = cll.correo;
                    clie.habilitado = cll.habilitado;
                    clie.comuna = cll.comuna;
                    db.Entry(clie).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Clientes");
                }

                return View(ccc);

            }
            else
            {
                return View("../Menu/Menu");
            }
            
        }


        //public ActionResult Delete(string rut)
        //{
        //    if (rut == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Clientes cll = db.Clientes.Find(rut);
        //    if (cll == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cll);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string rut)
        //{
        //    Clientes clie = db.Clientes.Find(rut);
        //    db.Clientes.Remove(clie);
        //    db.SaveChanges();
        //    return RedirectToAction("Clientes");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}