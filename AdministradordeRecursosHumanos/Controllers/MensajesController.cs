using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdministradordeRecursosHumanos.Models;

namespace AdministradordeRecursosHumanos.Controllers
{
    [Authorize]
    public class MensajesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mensajes
        public ActionResult Index()
        {
            var mensajes = db.Mensajes.Include(m => m.Empleado);
            return View(mensajes.ToList());
        }

        // GET: Mensajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensaje mensaje = db.Mensajes.Find(id);
            if (mensaje == null)
            {
                return HttpNotFound();
            }
            return View(mensaje);
        }

        // GET: Mensajes/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "Nombre");
            return View();
        }

        // POST: Mensajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MensajeId,EmpleadoId,Texto,FechaDeEnvio")] Mensaje mensaje)
        {
            if (ModelState.IsValid)
            {
                db.Mensajes.Add(mensaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "Nombre", mensaje.EmpleadoId);
            return View(mensaje);
        }

    }
}
