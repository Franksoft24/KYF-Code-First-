using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYF_Code_First_.Models;
using KYF_Code_First_.Context;
using Microsoft.AspNet.Identity;

namespace KYF_Code_First_.Controllers
{
    public class TarjetaController : Controller
    {
        private KYFcontext db = new KYFcontext();

        // GET: /Tarjeta/
        [Authorize]
        public ActionResult Index()
        {
            var userName = User.Identity.GetUserName();
            //var tarjeta = db.Tarjeta.Where(b => b.Propietario == userName);
            var tarjeta = db.Tarjeta.Include(t => t.TarjetaTipo).Where(b => b.Propietario == userName); ;
            return View(tarjeta.ToList());
        }

        // GET: /Tarjeta/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // GET: /Tarjeta/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TarjetaTipoID = new SelectList(db.TarjetaTipo, "TarjetatipoID", "Descripcion");
            
            return View();
        }

        // POST: /Tarjeta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "TarjetaID,NumeroTarjeta,EntidadBancaria,TarjetaTipoID,Propietario,Monto,fechaCorte")] Tarjeta tarjeta)
        {
            var userName = User.Identity.GetUserName();
            tarjeta.Propietario = userName;

            if (ModelState.IsValid)
            {
                db.Tarjeta.Add(tarjeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TarjetaTipoID = new SelectList(db.TarjetaTipo, "TarjetatipoID", "Descripcion", tarjeta.TarjetaTipoID);
            return View(tarjeta);
        }

        // GET: /Tarjeta/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.TarjetaTipoID = new SelectList(db.TarjetaTipo, "TarjetatipoID", "Descripcion", tarjeta.TarjetaTipoID);
            return View(tarjeta);
        }

        // POST: /Tarjeta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "TarjetaID,NumeroTarjeta,EntidadBancaria,TarjetaTipoID,Propietario,Monto,fechaCorte")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TarjetaTipoID = new SelectList(db.TarjetaTipo, "TarjetatipoID", "Descripcion", tarjeta.TarjetaTipoID);
            return View(tarjeta);
        }

        // GET: /Tarjeta/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // POST: /Tarjeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarjeta tarjeta = db.Tarjeta.Find(id);
            db.Tarjeta.Remove(tarjeta);
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
