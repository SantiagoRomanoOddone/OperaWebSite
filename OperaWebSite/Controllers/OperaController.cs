using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OperaWebSite.Models; //a
using OperaWebSite.Data; // a
using System.Data.Entity; // a
using System.Diagnostics; //A
using OperaWebSite.Filters;//a

namespace OperaWebSite.Controllers
{
    [MyFilterAction]
    public class OperaController : Controller
    {
        // Crear Instancia del dbcontext 

        private OperaDbContext context = new OperaDbContext();

        // GET: Opera
        public ActionResult Index()
        {
            //Traer todas Operas usando EF
            var operas = context.Operas.ToList();
            // el controller retorna una vista "Index" con una lista de operas
            return View("Index", operas);
        }

        //Creamos dos métodos para la inserción de la opera en la DB

        //primer create por GET para retornar la vista de registro

        [HttpGet] // el Get es implicito, así y todo lo podemos indicar
        public ActionResult Create()
        {
            // creamos la instancia sin valores en las properties
            Opera opera = new Opera();
            //retornamos la vista "Create" que tiene el objeto opera

            return View("Create", opera);
        }

        // Segundo create es por POST para insertar la nueva opera en la base 
        // cuando el usuario en la vista create hace click en enviar 
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("create", opera);
        }
        //Metodo Detalles
        // GET
        // Opera/Detail/id
        [HttpGet]// opcional, el default es get
        public ActionResult Detail (int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Detail",opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //GET /Opera/Delete/Id
        [HttpGet]// default get pero lo escribimos igual no molesta
        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Opera/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);

            context.Operas.Remove(opera);
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        //GET /Opera/Edit/id
        [HttpGet]
        public ActionResult Edit (int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Edit", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", opera);
        }

        //TODO Falto lo de years

       public ActionResult SearchByYear(int year)
        {
            if (year == 0)
            {
                return RedirectToAction("Index");
            }
            List<Opera> operaYears = (
                from o in context.Operas
                where o.Year == year
                select o).ToList();
            return View("Index", operaYears);
        }
    }
}