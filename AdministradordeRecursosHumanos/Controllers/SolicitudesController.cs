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
    public class SolicitudesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Solicitudes
        public ActionResult Index()
        {
            var solicituds = db.Solicituds.Include(s => s.Empleado);
            return View(solicituds.ToList());
        }

        // GET: Solicitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicituds.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View(solicitud);
        }

        // GET: Solicitudes/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "Nombre");
            return View();
        }

        // POST: Solicitudes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SolicitudId,TipoSolicitud,Tema,Texto,EmpleadoId,FechaInicialRango,FechaFinalRango,Estado_solicitud")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Solicituds.Add(solicitud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "Nombre", solicitud.EmpleadoId);
            return View(solicitud);
        }

        
    }
}
