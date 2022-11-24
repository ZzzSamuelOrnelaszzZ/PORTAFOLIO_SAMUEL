using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PORTAFOLIO_SAMUEL.Models;

namespace PORTAFOLIO_SAMUEL.Controllers
{
    public class HabilidadsController : Controller
    {
        private portafolioEntities db = new portafolioEntities();

        // GET: Habilidads
        public ActionResult Index()
        {
            var habilidads = db.Habilidads.Include(h => h.AspNetUser);
            return View(habilidads.ToList());
        }

        // GET: Habilidads/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habilidad habilidad = db.Habilidads.Find(id);
            if (habilidad == null)
            {
                return HttpNotFound();
            }
            return View(habilidad);
        }

        // GET: Habilidads/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Habilidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UsuarioId,Nombre,Dominio")] Habilidad habilidad)
        {
            if (ModelState.IsValid)
            {
                db.Habilidads.Add(habilidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", habilidad.UsuarioId);
            return View(habilidad);
        }

        // GET: Habilidads/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habilidad habilidad = db.Habilidads.Find(id);
            if (habilidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", habilidad.UsuarioId);
            return View(habilidad);
        }

        // POST: Habilidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UsuarioId,Nombre,Dominio")] Habilidad habilidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(habilidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", habilidad.UsuarioId);
            return View(habilidad);
        }

        // GET: Habilidads/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habilidad habilidad = db.Habilidads.Find(id);
            if (habilidad == null)
            {
                return HttpNotFound();
            }
            return View(habilidad);
        }

        // POST: Habilidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Habilidad habilidad = db.Habilidads.Find(id);
            db.Habilidads.Remove(habilidad);
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
