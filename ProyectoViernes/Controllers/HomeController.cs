using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoViernes.Models;

namespace ProyectoViernes.Controllers
{
    public class HomeController : Controller
    {
        PruebaMVCEntities entities = new PruebaMVCEntities();

        public ActionResult Index()
        {
            var listaCargo = entities.Tb_Provedores;
            return View(listaCargo.ToList());
        }
        public ActionResult Listarcargo ()
        {
            var listaCarg = entities.Tb_Provedores;
            return View(listaCarg.ToList());
        }

        public ActionResult ListarPorNombre (string  nombre)
        {
            var model = from p in entities.Tb_Provedores
                        where p.Nombre == nombre
                        select p;
            return View(model.ToList());
        }

        public ActionResult listarProductoXNombre (string nombre )
        {
            var modelProd = from mp in entities.Tb_Productos
                            where mp.Nombre == nombre
                            select mp;
            return View(modelProd.ToList());
        }

        public ActionResult ListarProductos ()
        {
            var listarProductos = entities.Tb_Productos;
            return View(listarProductos.ToList());
        }

        public ActionResult ListarProductosXProveder(int idProvedor)
        {
            var model = from pr in entities.Tb_Productos
                        where pr.IdProvedor == idProvedor
                        join pro in entities.Tb_Provedores
                        on pr.IdProvedor equals pro.IdProvedor
                        select new Provedores {
                            Nombre = pro.Nombre
                        };
            return View(model.ToList());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}