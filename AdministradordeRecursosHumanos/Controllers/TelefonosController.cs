﻿using System;
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
    public class TelefonosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Telefonos
        public ActionResult Index()
        {
            var telefonoes = db.Telefonoes.Include(t => t.Empleado);
            return View(telefonoes.ToList());
        }

        // GET: Telefonos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // GET: Telefonos/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "Nombre");
            return View();
        }

        // POST: Telefonos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TelefonoId,Tipo,NroTelefono,EmpleadoId")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Telefonoes.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "Nombre", telefono.EmpleadoId);
            return View(telefono);
        }

        // GET: Telefonos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "Nombre", telefono.EmpleadoId);
            return View(telefono);
        }

        // POST: Telefonos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TelefonoId,Tipo,NroTelefono,EmpleadoId")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "EmpleadoId", "Nombre", telefono.EmpleadoId);
            return View(telefono);
        }

        // GET: Telefonos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefono telefono = db.Telefonoes.Find(id);
            db.Telefonoes.Remove(telefono);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
