using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMotAppointments.Models.Repositories;
using MVCMotAppointments.Models;

namespace MVCMotAppointments.Controllers
{
    public class MotCentreController : Controller
    {
        private IMotCentreRepository repository = null;

        // Constructors to initiliase IMotCentreRepository repository object
        public MotCentreController()
        {
            this.repository = new MotCentreRepository();
        }

        public MotCentreController(IMotCentreRepository repository)
        {
            this.repository = repository;
        }

        // Return list of mot centre entities in the index view
        [HttpGet]
        public ActionResult Index()
        {
            List<MotCentre> model = (List<MotCentre>)repository.SelectAll();
            return View(model);
        }

        // Return view to show details of the currently selected mot centre
        [HttpGet]
        public ActionResult Details(int id)
        {
            MotCentre existing = repository.SelectByID(id);
            if (existing == null)
            {
                return HttpNotFound();
            }
            return View(existing);
        }

        // Return view to create a new mot centre
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Create a new mot centre instance, update the database and redirect back to the index view
        [HttpPost]
        public ActionResult Create(MotCentre obj)
        {
            if (ModelState.IsValid)
            { // check valid state
                repository.Insert(obj);
                repository.Save();
                return RedirectToAction("Index");
            }
            else // not valid so redisplay
            {
                return View(obj);
            }
        }

        // Return view to edit an existing mot centre
        [HttpGet, ActionName("Edit")]
        public ActionResult ConfirmEdit(int id)
        {
            MotCentre existing = repository.SelectByID(id);
            if (existing == null)
            {
                return HttpNotFound();
            }
            return View(existing);
        }

        // Update the mot centre details, update the database and redirect to the index page
        [HttpPost]
        public ActionResult Edit(MotCentre obj)
        {
            if (ModelState.IsValid)
            { // check valid state
                repository.Update(obj);
                repository.Save();
                return RedirectToAction("Index");
            }
            else // not valid so redisplay
            {
                return View(obj);
            }
        }

        // Returns the view to delete an mot centre
        [HttpGet, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            MotCentre existing = repository.SelectByID(id);
            if (existing == null)
            {
                return HttpNotFound();
            }
            return View(existing);
        }

        // Delete the selected mot centre, remove it from the database and redirect to the index page
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }
    }
}