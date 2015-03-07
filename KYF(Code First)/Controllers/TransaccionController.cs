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
    public class TransaccionController : Controller
    {
        private KYFcontext db = new KYFcontext();

        // GET: /Transaccion/
        [Authorize]
        public ActionResult Index()
        {
            var userName = User.Identity.GetUserName();
            var transaccion = db.Transaccion.Include(t => t.Motivo).Include(t => t.Tarjeta).Where(t=> t.Tarjeta.Propietario==userName);
            return View(transaccion.ToList());
        }

        // GET: /Transaccion/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: /Transaccion/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.MotivoID = new SelectList(db.Motivo, "MotivoID", "Nombre");
            var userName = User.Identity.GetUserName();
            ViewBag.TarjetaID = new SelectList(db.Tarjeta.Where(x => x.Propietario == userName), "TarjetaID", "NumeroTarjeta");
            return View();
        }

        // POST: /Transaccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include="TransaccionID,Descripcion,Monto,MotivoID,TarjetaID,fecha")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transaccion.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MotivoID = new SelectList(db.Motivo, "MotivoID", "Nombre", transaccion.MotivoID);
            ViewBag.TarjetaID = new SelectList(db.Tarjeta, "TarjetaID", "NumeroTarjeta", transaccion.TarjetaID);
            return View(transaccion);
        }

        // GET: /Transaccion/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.MotivoID = new SelectList(db.Motivo, "MotivoID", "Nombre", transaccion.MotivoID);
            ViewBag.TarjetaID = new SelectList(db.Tarjeta, "TarjetaID", "NumeroTarjeta", transaccion.TarjetaID);
            return View(transaccion);
        }

        // POST: /Transaccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include="TransaccionID,Descripcion,Monto,MotivoID,TarjetaID,fecha")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MotivoID = new SelectList(db.Motivo, "MotivoID", "Nombre", transaccion.MotivoID);
            ViewBag.TarjetaID = new SelectList(db.Tarjeta, "TarjetaID", "NumeroTarjeta", transaccion.TarjetaID);
            return View(transaccion);
        }

        // GET: /Transaccion/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: /Transaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transaccion.Find(id);
            db.Transaccion.Remove(transaccion);
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
