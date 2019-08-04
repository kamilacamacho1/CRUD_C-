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
    public class ProductosController : Controller
    {
        private PruebaMVCEntities db = new PruebaMVCEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var tb_Productos = db.Tb_Productos.Include(t => t.Tb_Provedores);
            return View(tb_Productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Productos tb_Productos = db.Tb_Productos.Find(id);
            if (tb_Productos == null)
            {
                return HttpNotFound();
            }
            return View(tb_Productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.IdProvedor = new SelectList(db.Tb_Provedores, "IdProvedor", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,Nombre,Precio,Cantidad,Descripcion,IdProvedor")] Tb_Productos tb_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Productos.Add(tb_Productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProvedor = new SelectList(db.Tb_Provedores, "IdProvedor", "Nombre", tb_Productos.IdProvedor);
            return View(tb_Productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Productos tb_Productos = db.Tb_Productos.Find(id);
            if (tb_Productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProvedor = new SelectList(db.Tb_Provedores, "IdProvedor", "Nombre", tb_Productos.IdProvedor);
            return View(tb_Productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,Nombre,Precio,Cantidad,Descripcion,IdProvedor")] Tb_Productos tb_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Productos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProvedor = new SelectList(db.Tb_Provedores, "IdProvedor", "Nombre", tb_Productos.IdProvedor);
            return View(tb_Productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Productos tb_Productos = db.Tb_Productos.Find(id);
            if (tb_Productos == null)
            {
                return HttpNotFound();
            }
            return View(tb_Productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_Productos tb_Productos = db.Tb_Productos.Find(id);
            db.Tb_Productos.Remove(tb_Productos);
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
