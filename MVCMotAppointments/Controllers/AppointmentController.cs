using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMotAppointments.Models.Repositories;
using MVCMotAppointments.Models;

namespace MVCMotAppointments.Controllers
{
    public class AppointmentController : Controller
    {
        private IAppointmentRepository repository = null;

        // Constructors to initiliase IAppointmentRepository repository object
        public AppointmentController()
        {
            this.repository = new AppointmentRepository();
        }

        public AppointmentController(IAppointmentRepository repository)
        {
            this.repository = repository;
        }

        // Return list of appointment entities in the index view
        [HttpGet]
        public ActionResult Index()
        {
            List<Appointment> model = (List<Appointment>)repository.SelectAll();
            return View(model);
        }

        // Return view to show details of the currently selected appointment
        [HttpGet]
        public ActionResult Details(int id)
        {
            Appointment existing = repository.SelectByID(id);
            if (existing == null)
            {
                return HttpNotFound();
            }
            return View(existing);
        }

        // Return view with a list of appointments associated with a certain mot centre
        [HttpGet]
        public ActionResult AssociatedAppointments(int id)
        {
            List<Appointment> model = (List<Appointment>)repository.SelectAppointmentsByCentreId(id);
            return View(model);
        }

        // Return view to create a new appointment
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Create a new appointment instance, update the database and redirect back to the index view
        [HttpPost]
        public ActionResult Create(Appointment obj)
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

        // Return view to edit an existing appointment
        [HttpGet, ActionName("Edit")]
        public ActionResult ConfirmEdit(int id)
        {
            Appointment existing = repository.SelectByID(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            return View(existing);
        }

        // Update the appointment details, update the database and redirect to the index page
        [HttpPost]
        public ActionResult Edit(Appointment obj)
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

        // Returns the view to delete an appointment
        [HttpGet, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Appointment existing = repository.SelectByID(id);
            if (existing == null)
            {
                return HttpNotFound();
            }
            return View(existing);
        }

        // Delete the selected appointment, remove it from the database and redirect to the index page
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }
    }
}