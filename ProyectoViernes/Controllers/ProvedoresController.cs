using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoViernes.Models;

namespace ProyectoViernes.Controllers
{
    public class ProvedoresController : Controller
    {
        private PruebaMVCEntities db = new PruebaMVCEntities();

        // GET: Provedores
        public ActionResult Index()
        {
            return View(db.Tb_Provedores.ToList());
        }

        // GET: Provedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Provedores tb_Provedores = db.Tb_Provedores.Find(id);
            if (tb_Provedores == null)
            {
                return HttpNotFound();
            }
            return View(tb_Provedores);
        }

        // GET: Provedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProvedor,Nombre")] Tb_Provedores tb_Provedores)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Provedores.Add(tb_Provedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Provedores);
        }

        // GET: Provedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Provedores tb_Provedores = db.Tb_Provedores.Find(id);
            if (tb_Provedores == null)
            {
                return HttpNotFound();
            }
            return View(tb_Provedores);
        }

        // POST: Provedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProvedor,Nombre")] Tb_Provedores tb_Provedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Provedores).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Provedores);
        }

        // GET: Provedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Provedores tb_Provedores = db.Tb_Provedores.Find(id);
            if (tb_Provedores == null)
            {
                return HttpNotFound();
            }
            return View(tb_Provedores);
        }

        // POST: Provedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_Provedores tb_Provedores = db.Tb_Provedores.Find(id);
            db.Tb_Provedores.Remove(tb_Provedores);
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
