using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CedroBackend.Models;

namespace CedroBackend.Controllers
{
    public class PratoViewController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: PratoView
        public ActionResult Index()
        {
            var pratoes = db.Pratoes.Include(p => p.Restaurante);
            return View(pratoes.ToList());
        }

        // GET: PratoView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratoes.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // GET: PratoView/Create
        public ActionResult Create()
        {
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "RestauranteId", "Nome");
            return View();
        }

        // POST: PratoView/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PratoId,Nome,IdRestaurante")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Pratoes.Add(prato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "RestauranteId", "Nome", prato.IdRestaurante);
            return View(prato);
        }

        // GET: PratoView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratoes.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "RestauranteId", "Nome", prato.IdRestaurante);
            return View(prato);
        }

        // POST: PratoView/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PratoId,Nome,IdRestaurante")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "RestauranteId", "Nome", prato.IdRestaurante);
            return View(prato);
        }

        // GET: PratoView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratoes.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: PratoView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prato prato = db.Pratoes.Find(id);
            db.Pratoes.Remove(prato);
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
